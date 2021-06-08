using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagniFinance.Domain.Entities
{
    public abstract class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }    
    }
}
