using MagniFinance.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MagniFinance.Web.Models
{
    public class StudentDTO
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public long RegistrationNumber { get; set; }
        public string SubjectName { get; set; }
        public double? GradeValue { get; set; }

        public static IEnumerable<StudentDTO> MapperList(Student student)
        {
            List<StudentDTO> listSubjects = new List<StudentDTO>();

            if (!student.Grades.Any())
            {
                listSubjects.Add(new StudentDTO
                {
                    ID = student.ID,
                    Name = student.Name,
                    Birthday = student.Birthday,
                    RegistrationNumber = student.RegistrationNumber,

                });
            }
            else
            {
                foreach (var grade in student.Grades)
                {
                    listSubjects.Add(new StudentDTO
                    {
                        ID = student.ID,
                        Name = student.Name,
                        RegistrationNumber = student.RegistrationNumber,
                        Birthday = student.Birthday,
                        SubjectName = grade.Subject.Name,
                        GradeValue = grade.GradeValue,
                    });
                }
            }
            return listSubjects;
        }
        public static StudentDTO Mapper(Student student)
        {

            return new StudentDTO
            {
                ID = student.ID,
                Name = student.Name,
                Birthday = student.Birthday,
                RegistrationNumber = student.RegistrationNumber,

            };

        }
    }
}