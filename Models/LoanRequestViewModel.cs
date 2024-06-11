using System.ComponentModel.DataAnnotations;

namespace ASCO.Models
{
    public class LoanRequestViewModel
    {
        [Required]
        [Display(Name = "Farmer ID")]
        public int farmer_id { get; set; }

        [Required]
        public int SelectedLoanAmount { get; set; }
    }
}