using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medicalreferrals.Models
{
    public class ChangeBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Փոփոխման հիմքի ID")]
        public int ChangeBaseId { get; set; }

        [Display(Name = "Փոփոխման հիմքի կոդ")]
        public string ChangeBaseCode { get; set; }

        [Display(Name = "Փոփոխման հիմքի անվանում")]
        public string ChangeBaseName { get; set; }
    }
}