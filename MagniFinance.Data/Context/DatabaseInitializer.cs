using MagniFinance.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace MagniFinance.Data.Context
{
    public class DatabaseInitializer : DropCreateDatabaseAlways<ConnectionContext>
    {
        protected override void Seed(ConnectionContext context)
        {
            IList<Course> defaultCourses = new List<Course>();
            defaultCourses.Add(new Course() { ID = Guid.NewGuid(), Name = "Biology" });
            defaultCourses.Add(new Course() { ID = Guid.NewGuid(), Name = "Matemathic" });
            defaultCourses.Add(new Course() { ID = Guid.NewGuid(), Name = "Computer Science" });
            defaultCourses.Add(new Course() { ID = Guid.NewGuid(), Name = "Machine Learning" });
            context.Courses.AddRange(defaultCourses);

            IList<Teacher> defaultTeachers = new List<Teacher>();
            defaultTeachers.Add(new Teacher() { ID = Guid.NewGuid(), Name = "Joao", Birthday = new DateTime(1991, 11, 26), Salary = 1000 });
            defaultTeachers.Add(new Teacher() { ID = Guid.NewGuid(), Name = "Marcos", Birthday = new DateTime(1981, 04, 13), Salary = 900 });
            defaultTeachers.Add(new Teacher() { ID = Guid.NewGuid(), Name = "Nuno", Birthday = new DateTime(1996, 01, 10), Salary = 1500 });
            defaultTeachers.Add(new Teacher() { ID = Guid.NewGuid(), Name = "Alice", Birthday = new DateTime(1972, 10, 04), Salary = 4000 });
            defaultTeachers.Add(new Teacher() { ID = Guid.NewGuid(), Name = "Ana", Birthday = new DateTime(1984, 02, 08), Salary = 6151 });
            context.Teachers.AddRange(defaultTeachers);

            var DiscretMathId = Guid.NewGuid();
            var DataStructureId = Guid.NewGuid();
            var AlgebraId = Guid.NewGuid();
            var BotanyId = Guid.NewGuid();
            var GeneticsId = Guid.NewGuid();
            var MicrobiologyId = Guid.NewGuid();
            IList<Subject> defaultSubjects = new List<Subject>();
            defaultSubjects.Add(new Subject() { ID = DiscretMathId, Name = "Discret Math", CourseId = defaultCourses[2].ID, TeacherId = defaultTeachers[2].ID });
            defaultSubjects.Add(new Subject() { ID = DataStructureId, Name = "Data Structure", CourseId = defaultCourses[2].ID,  TeacherId = defaultTeachers[0].ID});
            defaultSubjects.Add(new Subject() { ID = AlgebraId, Name = "Algebra", CourseId = defaultCourses[2].ID,  TeacherId = defaultTeachers[3].ID });
            defaultSubjects.Add(new Subject() { ID = BotanyId, Name = "Botany", CourseId = defaultCourses[0].ID, TeacherId = defaultTeachers[4].ID });
            defaultSubjects.Add(new Subject() { ID = GeneticsId, Name = "Genetics", CourseId = defaultCourses[0].ID,  TeacherId = defaultTeachers[4].ID });
            defaultSubjects.Add(new Subject() { ID = MicrobiologyId, Name = "Microbiology", CourseId = defaultCourses[0].ID, TeacherId = defaultTeachers[4].ID });
            context.Subjects.AddRange(defaultSubjects);

            IList<Student> defaultStudents = new List<Student>();
            defaultStudents.Add(new Student() { ID = Guid.NewGuid(), Name = "Luiz", Birthday = new DateTime(1991, 11, 26), RegistrationNumber = 56541 });
            defaultStudents.Add(new Student() { ID = Guid.NewGuid(), Name = "Rodrigo", Birthday = new DateTime(1981, 04, 13), RegistrationNumber = 99944 });
            defaultStudents.Add(new Student() { ID = Guid.NewGuid(), Name = "Maria", Birthday = new DateTime(1996, 01, 10), RegistrationNumber = 664 });
            defaultStudents.Add(new Student() { ID = Guid.NewGuid(), Name = "Sara", Birthday = new DateTime(1972, 10, 04), RegistrationNumber = 54896 });
            defaultStudents.Add(new Student() { ID = Guid.NewGuid(), Name = "Maria", Birthday = new DateTime(1984, 02, 08), RegistrationNumber = 9879 });
            context.Students.AddRange(defaultStudents);


            IList<Grade> defaultGrades = new List<Grade>();
            defaultGrades.Add(new Grade() { ID = Guid.NewGuid(), GradeValue = 5.6, StudentId = defaultStudents[0].ID, SubjectId = DiscretMathId });
            defaultGrades.Add(new Grade() { ID = Guid.NewGuid(), GradeValue = 8, StudentId = defaultStudents[0].ID, SubjectId = DataStructureId });
            defaultGrades.Add(new Grade() { ID = Guid.NewGuid(), GradeValue = 4, StudentId = defaultStudents[0].ID, SubjectId = AlgebraId });
            defaultGrades.Add(new Grade() { ID = Guid.NewGuid(), GradeValue = 8, StudentId = defaultStudents[1].ID, SubjectId = BotanyId });
            defaultGrades.Add(new Grade() { ID = Guid.NewGuid(), GradeValue = 9.5, StudentId = defaultStudents[1].ID, SubjectId = GeneticsId });
            defaultGrades.Add(new Grade() { ID = Guid.NewGuid(), GradeValue = 2, StudentId = defaultStudents[2].ID, SubjectId = MicrobiologyId });
            defaultGrades.Add(new Grade() { ID = Guid.NewGuid(), GradeValue = 8.5, StudentId = defaultStudents[2].ID, SubjectId = GeneticsId });
            defaultGrades.Add(new Grade() { ID = Guid.NewGuid(), GradeValue = 8.5, StudentId = defaultStudents[2].ID, SubjectId = GeneticsId });
            context.Grades.AddRange(defaultGrades);

            base.Seed(context);
        }
    }
}
