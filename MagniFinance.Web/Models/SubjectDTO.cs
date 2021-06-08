using MagniFinance.Domain.Entities;
using System;
using System.Linq;

namespace MagniFinance.Web.Models
{
    public class SubjectDTO
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string TeacherName { get; set; }
        public long? StudentsCount { get; set; }
        public double? AvarageGrades { get; set; }


        public static SubjectDTO Mapper(Subject subject)
        {
            return new SubjectDTO
            {
                ID = subject.ID,
                Name = subject.Name,
                TeacherName = subject.Teacher.Name,
                StudentsCount = subject.Grades.Any() ? subject.Grades.Select(x => x.StudentId)?.Distinct().Count() : 0,
                AvarageGrades = subject.Grades.Any() ? subject.Grades.Average(x => x.GradeValue) : 0
            };
        }

    }
}