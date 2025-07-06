using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using LoanFrontendIntegration.CustomValidations;

namespace LoanFrontendIntegration.Models
{
    public class Loan
    {
        public string LoanId { get; set; }


        [Required(ErrorMessage = "Select Loan Type")] //Use DropDown
        public string LoanType { get; set; }


        [Required(ErrorMessage = "Interest Rate")] //Use Random
        public double LoanInterest { get; set; }


        [Required(ErrorMessage = "Enter Loan Amount Required")] 
        public double LoanPrincipal { get; set; }

        //Payment Button
        public double Repay { get; set; }

        //Principal = Principal - Repay
        public double AmountLeft { get; set; }


        public DateTime LoanTakenDate { get; set; } = DateTime.Now;


        [Required(ErrorMessage = "Enter Loan Repayment Date")] 
        [RepaymentDateValidator(ErrorMessage = "Repayment Date Invalid")]
        public DateTime LoanRepaymentDate { get; set; }


        public string UserId { get; set; } //Taken through Session


        public string UserName { get; set; } //Taken through session


        public int CreditScore { get; set; } //Taken through session


        public string Remarks { get; set; }

        public string Status { get; set; } = "Pending"; //Add DropDown Input -> Accepted (Green), Rejected (Red), Pending (Yellow)

    }
}
