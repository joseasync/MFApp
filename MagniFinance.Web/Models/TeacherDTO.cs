using MagniFinance.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MagniFinance.Web.Models
{
    public class TeacherDTO
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public virtual DateTime Birthday { get; set; }
        public long Salary { get; set; }

        public static TeacherDTO Mapper(Teacher teacher)
        {
            return new TeacherDTO
            {
                ID = teacher.ID,
                Name = teacher.Name,
                Birthday = teacher.Birthday,
                Salary = teacher.Salary,
                
            };
        }
    }
}