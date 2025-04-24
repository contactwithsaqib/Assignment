using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Model
{
    public class District
    {
        public short Id { get; set; }

        [Required]
        [Display(Name = "District")]
        public string DistrictName { get; set; }

        [Required]
        public short StateId { get; set; }

        [ForeignKey("StateId")]
        public State State { get; set; }
    }

}
