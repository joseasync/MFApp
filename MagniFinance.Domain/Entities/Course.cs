using System.Collections.Generic;

namespace MagniFinance.Domain.Entities
{
    public class Course : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }

    }
}
