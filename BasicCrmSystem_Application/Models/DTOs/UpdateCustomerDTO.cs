using System.ComponentModel.DataAnnotations;

namespace BasicCrmSystem_Application.Models.DTOs
{
    public class UpdateCustomerDTO
    {
        public int Id { get; set; }
        [MinLength(3, ErrorMessage = "Firstname cannot enter less than 3 characters"), Required(ErrorMessage = "This field is required"), MaxLength(50, ErrorMessage = "Firstname cannot enter more than 50 characters")]
        public string? FirstName { get; set; }
        [MinLength(2, ErrorMessage = "Lastname cannot enter less than 2 characters"), Required(ErrorMessage = "This field is required"), MaxLength(50, ErrorMessage = "Lastname cannot enter more than 50 characters")]
        public string? LastName { get; set; }
        [MinLength(5, ErrorMessage = "Email cannot enter less than 5 characters"), Required(ErrorMessage = "This field is required"), DataType(DataType.EmailAddress), MaxLength(200, ErrorMessage = "Email cannot enter more than 200 characters")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public int RegionId { get; set; }

    }
}
