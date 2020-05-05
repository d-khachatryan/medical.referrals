using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medicalreferrals.Models
{
    [Table("vwReferralService", Schema = "log")]
    public class ReferralServiceLogItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ՀՀ")]
        public int ReferralServiceLogId { get; set; }

        public int ReferralServiceId { get; set; }
        public int? ReferralId { get; set; }

        [Display(Name = "Ծառայության կոդը")]
        public string ServiceCode { get; set; }

        [Display(Name = "Ծառայության անվանումը")]
        public string ServiceName { get; set; }

        [Display(Name = "Ծառայության արժեքը")]
        public double? ServiceCost { get; set; }

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
        public DateTime? ReferralServiceDate { get; set; }
    }
}