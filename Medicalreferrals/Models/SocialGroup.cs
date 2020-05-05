using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medicalreferrals.Models
{
    public class SocialGroup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Սոցկարգավիճակի ID")]
        public int SocialGroupId { get; set; }

        [Display(Name = "Սոցկարգավիճակի կոդ")]
        public string SocialGroupCode { get; set; }

        [Display(Name = "Սոցկարգավիճակի անվանում")]
        public string SocialGroupName { get; set; }
    }
}