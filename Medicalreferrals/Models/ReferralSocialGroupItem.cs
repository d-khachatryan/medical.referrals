using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medicalreferrals.Models
{
    [Table("vwReferralSocialGroup")]
    public class ReferralSocialGroupItem
    {
        [Key]
        public int ReferralSocialGroupId { get; set; }

        public int? ReferralId { get; set; }

        public int? SocialGroupId { get; set; }
        [Display(Name = "Սոցկարգավիճակի անվանում")]
        public string SocialGroupName { get; set; }
        [Display(Name = "Սոցկարգավիճակը հավաստող փաստաթղթի համար")]
        public string SocialGroupNumber { get; set; }
    }
}