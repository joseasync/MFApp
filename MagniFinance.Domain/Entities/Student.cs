using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MagniFinance.Domain.Entities
{
    public class Student : BaseUser
    {
        [Required]
        [Range(1, 99999999, ErrorMessage = "Registration Number is invalid")]
        public long RegistrationNumber { get; set; }

        public virtual ICollection<Grade> Grades { get; set; }
    }
}
