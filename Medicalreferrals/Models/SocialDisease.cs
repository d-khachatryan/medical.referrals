using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medicalreferrals.Models
{
    public class SocialDisease
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Սոցիալական հիվանդության ID")]
        public int SocialDiseaseId { get; set; }

        [Display(Name = "Սոցիալական հիվանդության կոդ")]
        public string SocialDiseaseCode { get; set; }

        [Display(Name = "Սոցիալական հիվանդության անվանում")]
        public string SocialDiseaseName { get; set; }
    }
}