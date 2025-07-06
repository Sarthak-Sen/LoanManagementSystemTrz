using System.ComponentModel.DataAnnotations;

namespace LoanFrontendIntegration.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Please Enter Username (Email) ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        public string Password { get; set; }
    }
}
