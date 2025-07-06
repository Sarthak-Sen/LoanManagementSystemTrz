using System.ComponentModel.DataAnnotations;

namespace LoanFrontendIntegration.CustomValidations
{
    public class DobValidator : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if ((DateTime)value > DateTime.Now)
            {
                return new ValidationResult(base.ErrorMessage);
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}
