using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medicalreferrals.Models
{
    [Table("vwReferralSurgery", Schema = "log")]
    public class ReferralSurgeryLogItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ՀՀ")]
        public int ReferralSurgeryLogId { get; set; }

        public int ReferralSurgeryId { get; set; }

        public int? ReferralId { get; set; }

        [Display(Name = "Միջամտության կոդը")]
        public string SurgeryCode { get; set; }

        [Display(Name = "Միջամտության անվանումը")]
        public string SurgeryName { get; set; }

        [Display(Name = "Միջամտության արժեքը")]
        public double? SurgeryCost { get; set; }

        public string Id { get; set; }

        [Display(Name = "Գործարկող")]
        public string UserName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Փոփոխման իրականացմամ ամսաթիվ")]
        public DateTime? LogDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ամսաթիվ")]
        public DateTime? ReferralSurgeryDate { get; set; }
    }
}