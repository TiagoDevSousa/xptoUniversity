using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using xptoUniversity.Models;

namespace xptoUniversity.DAL
{
    public class SchoolInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<SchoolContext>
    {
        protected override void Seed(SchoolContext context)
        {
            var students = new List<Student>
            {
            new Student{Name="Carson",Birthday=DateTime.Parse("2005-09-01"), RegistrationNumber=901},
            new Student{Name="Meredith",Birthday=DateTime.Parse("2002-09-01"), RegistrationNumber=902},
            new Student{Name="Arturo",Birthday=DateTime.Parse("2003-09-01"), RegistrationNumber=903},
            new Student{Name="Gytis",Birthday=DateTime.Parse("2002-09-01"), RegistrationNumber=904},
            new Student{Name="Yan",Birthday=DateTime.Parse("2002-09-01"), RegistrationNumber=905},
            new Student{Name="Peggy",Birthday=DateTime.Parse("2001-09-01"), RegistrationNumber=906},
            new Student{Name="Laura",Birthday=DateTime.Parse("2003-09-01"), RegistrationNumber=907},
            new Student{Name="Nino",Birthday=DateTime.Parse("2005-09-01"), RegistrationNumber=908}
            };
            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();

            var teachers = new List<Teacher>
            {
            new Teacher{TeacherID= 91,Name="FQTeacher",Birthday=DateTime.Parse("1980-09-21"),Salary = 1000  },
            new Teacher{TeacherID= 92,Name="LiteratureTeacher",Birthday=DateTime.Parse("1982-12-25"),Salary = 2000  },
            new Teacher{TeacherID= 93,Name="EconomicsTeacher",Birthday=DateTime.Parse("1981-04-05"),Salary = 2500  },
            };
            teachers.ForEach(s => context.Teachers.Add(s));
            context.SaveChanges();

            var courses = new List<Course>
            {
            new Course{CourseID=1,Title="Engineering", },
            new Course{CourseID=2,Title="Literature", },
            new Course{CourseID=3,Title="Economics", }
            };
            courses.ForEach(s => context.Courses.Add(s));
            context.SaveChanges();

            var subjects = new List<Subject>
            {
            new Subject{SubjectID=1050,Title="Chemistry",TeacherID = 91},
            new Subject{SubjectID=4022,Title="Microeconomics",TeacherID = 92},
            new Subject{SubjectID=4041,Title="Macroeconomics",TeacherID = 92},
            new Subject{SubjectID=1045,Title="Calculus",TeacherID = 91},
            new Subject{SubjectID=3141,Title="Trigonometry",TeacherID = 91},
            new Subject{SubjectID=2021,Title="Composition",TeacherID = 93},
            new Subject{SubjectID=2042,Title="English Literature",TeacherID = 93}
            };
            subjects.ForEach(s => context.Subjects.Add(s));
            context.SaveChanges();

            var compoments = new List<Component>
            {
            new Component{CourseID=1, SubjectID=1050},
            new Component{CourseID=1, SubjectID=1045},
            new Component{CourseID=1, SubjectID=3141},
            new Component{CourseID=2, SubjectID=2021},
            new Component{CourseID=2, SubjectID=2042},
            new Component{CourseID=3, SubjectID=4022},
            new Component{CourseID=3, SubjectID=4041},
            new Component{CourseID=3, SubjectID=1045},
            };
            compoments.ForEach(s => context.Components.Add(s));
            context.SaveChanges();

            var enrollments = new List<Enrollment>
            {
            new Enrollment{StudentID=1,SubjectID=1050,Grade=Grade.A},
            new Enrollment{StudentID=1,SubjectID=4022,Grade=Grade.C},
            new Enrollment{StudentID=1,SubjectID=4041,Grade=Grade.B},
            new Enrollment{StudentID=2,SubjectID=1045,Grade=Grade.B},
            new Enrollment{StudentID=2,SubjectID=3141,Grade=Grade.F},
            new Enrollment{StudentID=2,SubjectID=2021,Grade=Grade.F},
            new Enrollment{StudentID=3,SubjectID=1050},
            new Enrollment{StudentID=4,SubjectID=1050,},
            new Enrollment{StudentID=4,SubjectID=4022,Grade=Grade.F},
            new Enrollment{StudentID=5,SubjectID=4041,Grade=Grade.C},
            new Enrollment{StudentID=6,SubjectID=1045},
            new Enrollment{StudentID=7,SubjectID=3141,Grade=Grade.A},
            };
            enrollments.ForEach(s => context.Enrollments.Add(s));
            context.SaveChanges();
        }
    }
}