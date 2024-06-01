using System.ComponentModel.DataAnnotations;

namespace ASCO.Models
{
    public class MachineryRequestViewModel
    {
        [Required]
        public int farmer_id { get; set; }

        [Required]
        public int SelectedMachineryType { get; set; }
    }
}
