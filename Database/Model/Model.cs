using System.ComponentModel.DataAnnotations;

namespace Database.Model
{
    public class Model : BaseEntity
    {
        [Required]
        public string Name { get; set; }
    }
}
