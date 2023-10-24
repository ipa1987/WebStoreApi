using System.ComponentModel.DataAnnotations;

namespace WebStoreApi.Models
{
    public class UserDto
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please provide Last Name")]
        public string LastName { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;
        [Required]
        [MinLength(5, ErrorMessage = "Address should have at least 5 characters")]
        [MaxLength(1000, ErrorMessage = "Address should not be more than 1000 characters")]
        public string Address {  get; set; } = string.Empty;
    }
}
