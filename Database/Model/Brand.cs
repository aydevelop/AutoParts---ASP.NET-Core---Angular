using System.ComponentModel.DataAnnotations;

namespace Database.Model
{
    public class Brand : BaseEntity
    {
        [Required]
        public string Name { get; set; }
    }
}
