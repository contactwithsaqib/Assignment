using System.ComponentModel.DataAnnotations;

namespace Assignment.Model
{
    public class Gender
    {
        [Key]
        public byte Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
