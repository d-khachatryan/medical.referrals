using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medicalreferrals.Models
{
    public class ReferralSocialGroup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReferralSocialGroupId { get; set; }

        public int? ReferralId { get; set; }
        [Display(Name = "Սոցկարգավիճակի անվանում")]
        public int? SocialGroupId { get; set; }
        [Display(Name = "Սոցկարգավիճակը հավաստող փաստաթղթի համար")]
        public string SocialGroupNumber { get; set; }
    }
}