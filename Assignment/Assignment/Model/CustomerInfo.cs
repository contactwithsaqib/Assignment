using System.ComponentModel.DataAnnotations;

namespace Assignment.Model
{
    public class CustomerInfo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Name must contain only alphabets")]
        [StringLength(50)]
        public string Name { get; set; }


        [Required(ErrorMessage = "GenderId is required")]
        [Range(1, 255, ErrorMessage = "GenderId must be between 1 and 255")]
        public byte GenderId { get; set; }

        [Required(ErrorMessage = "StateId is required")]
        public short StateId { get; set; }

        [Required(ErrorMessage = "DistrictId is required")]
        public short DistrictId { get; set; }

      
    }

}
