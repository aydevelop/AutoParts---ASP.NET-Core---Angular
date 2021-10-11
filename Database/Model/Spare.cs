using System;
using System.ComponentModel.DataAnnotations;

namespace Database.Model
{
    public class Spare : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Price { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Url { get; set; }


        public Guid ModelId { get; set; }
        public virtual Model Model { get; set; }

        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
