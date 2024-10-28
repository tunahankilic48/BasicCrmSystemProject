using System.ComponentModel.DataAnnotations;

namespace BasicCrmSystem_Application.Models.DTOs
{
    public class LoginDTO
    {
        [MinLength(6, ErrorMessage = "Username cannot enter less than 6 characters"), Required(ErrorMessage = "This field is required"), MaxLength(50, ErrorMessage = "Username cannot enter more than 50 characters")]
        public string? Username { get; set; }
        [MinLength(4, ErrorMessage = "Password cannot enter less than 4 characters"), Required(ErrorMessage = "This field is required"), MaxLength(50, ErrorMessage = "Username cannot enter more than 100 characters")]
        public string? Password { get; set; }
    }
}
