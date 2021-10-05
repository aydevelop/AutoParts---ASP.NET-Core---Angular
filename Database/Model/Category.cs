﻿using System.ComponentModel.DataAnnotations;

namespace Database.Model
{
    public class Category : BaseEntity
    {
        [Required]
        public string Name { get; set; }
    }
}
