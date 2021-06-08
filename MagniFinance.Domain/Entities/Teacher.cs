using System.Collections.Generic;

namespace MagniFinance.Domain.Entities
{
    public class Teacher : BaseUser
    {
        public long Salary { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }

    }
}
