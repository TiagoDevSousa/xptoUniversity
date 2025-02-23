﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using xptoUniversity.DAL;
using xptoUniversity.ViewModels;

namespace xptoUniversity.Controllers
{
    public class StatisticsController : Controller
    {
        private SchoolContext db = new SchoolContext();

        public ActionResult BirthdayStats()
        {

            IQueryable<BirthdayGroup> data = from student in db.Students
                                             group student by student.Birthday into dateGroup
                                             select new BirthdayGroup()
                                             {
                                                 Birthday = dateGroup.Key,
                                                 StudentCount = dateGroup.Count()
                                             };
            return View(data.ToList());
        }

        public ActionResult CourseStats()
        {
            IQueryable<CoursesGroup> teacherQ = from c in db.Courses
                                                join s in db.Subjects on c.CourseID equals s.CourseID
                                                join t in db.Teachers on s.TeacherID equals t.TeacherID
                                                group c by c.Title into courseGroup
                                                select new CoursesGroup()
                                                {
                                                    Course = courseGroup.Key,
                                                    TeachersCount = courseGroup.Count()
                                                };

            IQueryable<CoursesGroup> studentQ = from c in db.Courses
                                                join s in db.Subjects on c.CourseID equals s.CourseID
                                                join e in db.Enrollments on s.SubjectID equals e.SubjectID
                                                join st in db.Students on e.StudentID equals st.ID
                                                group e by c.Title into courseGroup
                                                select new CoursesGroup()
                                                {
                                                    Course = courseGroup.Key,
                                                    StudentsCount = courseGroup.Count(),
                                                    AvgGrade = courseGroup.Average(x => x.Grade),
                                                };


            var res = from s in studentQ.ToList()
                      join t in teacherQ.ToList() on s.Course equals t.Course into rq
                      from r in rq.DefaultIfEmpty()
                      select new CoursesGroup()
                      {
                          Course = s.Course,
                          StudentsCount = s.StudentsCount,
                          AvgGrade = s.AvgGrade,
                          TeachersCount = r.TeachersCount
                      };


            return View(res.ToList());

        }

        public ActionResult SubjectStats()
        {
            IQueryable<SubjectGroup> teacherQ = from s in db.Subjects
                                                join t in db.Teachers on s.TeacherID equals t.TeacherID
                                                select new SubjectGroup()
                                                {
                                                    Subject = s.Title,
                                                    TeachersName = t.Name,
                                                    TeachersSalary = t.Salary,
                                                    TeachersBirthday = t.Birthday
                                                };

            var enrollmentQ = (from e in db.Enrollments
                               join st in db.Students on e.StudentID equals st.ID
                               join s in db.Subjects on e.SubjectID equals s.SubjectID
                               select new
                               {
                                   Subject = s.Title,
                                   StudentName = st.Name
                               }).ToList();

            var GradesQ = (from e in db.Enrollments
                           join s in db.Subjects on e.SubjectID equals s.SubjectID
                           select new
                           {
                               Subject = s.Title,
                               Grade = e.Grade
                           }).ToList();

            var teacherList = teacherQ.ToList();

            foreach (var item in teacherList)
            {
                item.StudentsCount = enrollmentQ.Count(x => x.Subject.Equals(item.Subject));
                item.Grades = GradesQ.Where(x => x.Subject.Equals(item.Subject)).Select(y => y.Grade).ToList();
            }

            return View(teacherList);
        }

        public ActionResult StudentStats()
        {
            //IQueryable<StudentGroup> studentQ = from e in db.Enrollments
            //                                    join st in db.Students on e.StudentID equals st.ID
            //                                    join s in db.Subjects on e.SubjectID equals s.SubjectID
            //                                    select new StudentGroup()
            //                                    {
            //                                        StudentName = st.Name,
            //                                        Subject = s.Title,
            //                                        Grade = e.Grade
            //                                    };

            //var studentQ = from e in db.Enrollments
            //                                    join st in db.Students on e.StudentID equals st.ID
            //                                    join s in db.Subjects on e.SubjectID equals s.SubjectID
            //                                    group e by s.Title into g
            //                                    select new 
            //                                    {
            //                                        Subject = g.Key,
            //                                        Studendts = g.Select(m => m.Student),
            //                                        Grades = g.Select(m => m.Grade)
            //                                    };

            var studentQ = from e in db.Enrollments
                           join st in db.Students on e.StudentID equals st.ID
                           join s in db.Subjects on e.SubjectID equals s.SubjectID
                           select new
                           {
                               StudentName = st.Name,
                               Subject = s.Title,
                               Grade = e.Grade
                           };

            var studentQListGroup = studentQ.GroupBy(x => x.Subject).ToList();

            var res = new List<StudentSubjectGroup>();

            foreach (var item in studentQListGroup)
            {
                var studendtsGradesList = new List<StudendtsGrades>();

                foreach (var subItem in item)
                {
                    studendtsGradesList.Add(new StudendtsGrades()
                    {
                        StudentName = subItem.StudentName,
                        Grade = subItem.Grade
                    });

                };

                res.Add(new StudentSubjectGroup()
                {
                    Subject = item.Key,
                    StudendtsGrades = studendtsGradesList
                });


            }
            return View(res);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }


    }
}