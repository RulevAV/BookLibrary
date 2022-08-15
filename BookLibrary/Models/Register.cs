using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Models
{
    public class Register
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Username { get; set; }
        
        [Required]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Пароли не совпадают !")]
        public string ConfirmPassword { get; set; }

    }
}
