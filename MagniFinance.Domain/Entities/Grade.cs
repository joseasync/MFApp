using System;
namespace MagniFinance.Domain.Entities
{
    public class Grade : BaseEntity
    {
        public double GradeValue { get; set; }
        public Guid SubjectId { get; set; }
        public Guid StudentId { get; set; }

        public virtual Subject Subject { get; set; }
        public virtual Student Student { get; set; }
    }
}
