using System.ComponentModel.DataAnnotations;

namespace Assignment.Model
{
    public class State
    {
        public short Id { get; set; }

        [Required]
        [Display(Name = "State")]
        public string StateName { get; set; }

        public ICollection<District> Districts { get; set; }
    }

}
