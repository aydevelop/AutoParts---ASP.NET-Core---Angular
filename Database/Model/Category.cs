
using System.ComponentModel.DataAnnotations;

namespace Database.Model
{
    public class Category : BaseEntity
    {
        [Required]
        //[UniqueAttribute(typeof(Category))]
        public string Name { get; set; }
    }
}
