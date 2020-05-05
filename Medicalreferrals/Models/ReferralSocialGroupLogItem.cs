using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medicalreferrals.Models
{
    [Table("vwReferralSocialGroup", Schema = "log")]
    public class ReferralSocialGroupLogItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ՀՀ")]
        public int ReferralSocialGroupLogId { get; set; }

        public int ReferralSocialGroupId { get; set; }

        public int? ReferralId { get; set; }
        [Display(Name = "Սոցիալական խումբ")]
        public int? SocialGroupId { get; set; }

        [Display(Name = "Սոցիալական խումբ")]
        public int? SocialGroupName { get; set; }

        [Display(Name = "Սոցիալական խմբի համարը")]
        public string SocialGroupNumber { get; set; }

        public string Id { get; set; }

        [Display(Name = "Գործարկող")]
        public string UserName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Փոփոխման իրականացման ամսաթիվ")]
        public DateTime? LogDate { get; set; }
    }
}