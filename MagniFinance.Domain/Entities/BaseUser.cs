using System;
using System.ComponentModel.DataAnnotations;

namespace MagniFinance.Domain.Entities
{
    public class BaseUser : BaseEntity
    {
        [Required]
        [StringLength(200, ErrorMessage = "Name length must be between 3 and 200.", MinimumLength = 3)]
        public virtual string Name { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        public virtual DateTime Birthday { get; set; }
    }
}