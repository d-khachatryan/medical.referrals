using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medicalreferrals.Models
{
    [Table("vwReferralSocialDisease")]
    public class ReferralSocialDiseaseItem
    {
        [Key]
        public int ReferralSocialDiseaseId { get; set; }

        public int? ReferralId { get; set; }

        public int? SocialDiseaseId { get; set; }
        [Display(Name = "Սոցիալական հիվանդության անվանում")]
        public string SocialDiseaseName { get; set; }
    }
}