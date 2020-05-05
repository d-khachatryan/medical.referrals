using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medicalreferrals.Models
{
    public class ReferralSocialDisease
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReferralSocialDiseaseId { get; set; }

        public int? ReferralId { get; set; }
        [Display(Name = "Սոցիալական հիվանդության անվանում")]
        public int? SocialDiseaseId { get; set; }
    }
}