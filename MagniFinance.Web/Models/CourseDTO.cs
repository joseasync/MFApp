using MagniFinance.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MagniFinance.Web.Models
{
    public class CourseDTO
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public long? TeachersCount { get; set; }
        public long? StudentsCount { get; set; }
        public double? AvarageGrades { get; set; }
        
        public static CourseDTO Mapper(Course course)
        {
            IEnumerable<Grade> studentsCount = course.Subjects.Any() ? course.Subjects?.SelectMany(x => x.Grades) : new List<Grade>();


            return new CourseDTO
            {
                ID = course.ID,
                Name = course.Name,
                StudentsCount = studentsCount.Any() ? studentsCount.Select(x => x.StudentId)?.Distinct().Count() : 0,
                TeachersCount = course.Subjects.Any() ? course.Subjects.Select(x => x.TeacherId)?.Distinct().Count() : 0,
                AvarageGrades = studentsCount.Any() ? studentsCount.Average(x => x.GradeValue) : 0
            };
        }
    }
}