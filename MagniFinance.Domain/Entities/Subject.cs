using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MagniFinance.Domain.Entities
{
    public class Subject : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public Guid CourseId { get; set; }
        public Guid TeacherId { get; set; }

        public virtual ICollection<Grade> Grades { get; set; }
        public virtual Course Course { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}