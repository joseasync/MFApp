using MagniFinance.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MagniFinance.Web.Models
{
    public class GradeDTO
    {
        public Guid ID { get; set; }
        public double GradeValue { get; set; }
        public string SubjectName { get; set; }
        public string StudentName { get; set; }


        public static GradeDTO Mapper(Grade grade)
        {
            return new GradeDTO
            {
                ID = grade.ID,
                GradeValue = grade.GradeValue,
                StudentName = grade.Student.Name,
                SubjectName = grade.Subject.Name               
            };
        }
    }
}