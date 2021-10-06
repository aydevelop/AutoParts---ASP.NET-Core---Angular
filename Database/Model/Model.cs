using System;
using System.ComponentModel.DataAnnotations;

namespace Database.Model
{
    public class Model : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        public Guid BrandId { get; set; }
        public virtual Brand Brand { get; set; }
    }
}
