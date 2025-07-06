using System.ComponentModel.DataAnnotations;

namespace LoanFrontendIntegration.CustomValidations
{
    public class RepaymentDateValidator : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if ((DateTime)value < DateTime.Now)
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
