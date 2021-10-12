using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Model
{
    public abstract class BaseEntity
    {
        [Key]
        public virtual Guid Id { get; set; }
    }
}
