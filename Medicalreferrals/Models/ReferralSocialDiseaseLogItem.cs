using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medicalreferrals.Models
{
    [Table("vwReferralSocialDisease", Schema = "log")]
    public class ReferralSocialDiseaseLogItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ՀՀ")]
        public int ReferralSocialDiseaseLogId { get; set; }

        public int ReferralSocialDiseaseId { get; set; }

        public int? ReferralId { get; set; }
        [Display(Name = "Սոցիալական հիվանդություն")]
        public int? SocialDiseaseId { get; set; }

        [Display(Name = "Սոցիալական հիվանդության անվանում")]
        public string SocialDiseaseName { get; set; }

        public string Id { get; set; }

        [Display(Name = "Գործարկող")]
        public string UserName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Փոփոխման իրականացման ամսաթիվ")]
        public DateTime? LogDate { get; set; }
    }
}