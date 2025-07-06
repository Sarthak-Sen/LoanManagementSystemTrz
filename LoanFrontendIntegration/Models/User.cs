using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using LoanFrontendIntegration.CustomValidations;

namespace LoanFrontendIntegration.Models
{
    public class User
    {
        public string UserId { get; set; }

        [Required(ErrorMessage = "Enter Full Name")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Enter Date Of Birth")]
        [DobValidator(ErrorMessage = "Invalid DOB")]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Enter Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter Password")]
        //[RegularExpression("[a-zA-Z0-9]", ErrorMessage = "Invalid Format")]
        public string Password { get; set; }

        [Required(ErrorMessage = "ReEnter Password")]
        [Compare("Password", ErrorMessage = "Password Mismatch")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Enter Mobile")] 
        [RegularExpression("[6-9][0-9]{9}", ErrorMessage = "Invalid Mobile No")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "Enter Credit Score")]
        [Range(300, 900, ErrorMessage = "Invalid Credit Score")]
        public int CreditScore { get; set; }


        [Required(ErrorMessage = "Enter Role")] //Drop Down Input
        public string Role { get; set; } = "Customer";
    }
}
