using System;
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

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }


    }
}