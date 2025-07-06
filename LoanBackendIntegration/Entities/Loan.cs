using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LoanBackendIntegration.Entities
{
    public class Loan
    {

        [Key]
        [StringLength(20)]
        public string LoanId { get; set; }


        [Required]
        [StringLength(20)]
        [Column(TypeName = "varchar")]
        public string LoanType { get; set; }


        [Required]
        public double LoanInterest { get; set; }


        [Required]
        public double LoanPrincipal { get; set; }

        public double Repay { get; set; }


        public double AmountLeft { get; set; }


        [Required]
        public DateTime LoanTakenDate { get; set; }

        [Required]
        public DateTime LoanRepaymentDate { get; set; }


        [Required]
        [StringLength(20)]
        [Column(TypeName = "varchar")]
        public string UserId { get; set; }
        

        [Required]
        [StringLength(50)]
        [Column(TypeName = "varchar")]
        public string UserName { get; set; }


        [Required]
        public int CreditScore { get; set; }

       
        [StringLength(500)]
        [Column(TypeName = "varchar")]
        public string Remarks { get; set; }


        [StringLength(10)]
        [Column(TypeName = "varchar")]
        public string Status { get; set; } = "Pending";
    }
}
