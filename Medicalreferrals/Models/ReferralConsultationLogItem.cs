using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medicalreferrals.Models
{
    [Table("vwReferralConsultation", Schema = "log")]
    public class ReferralConsultationLogItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ՀՀ")]
        public int ReferralConsultationLogId { get; set; }

        public int? ReferralConsultationId { get; set; }
        public int? ReferralId { get; set; }

        [Display(Name = "Խորհրդատվության կոդը")]
        public string ConsultationCode { get; set; }

        [Display(Name = "Խորհրդատվության անվանումը")]
        public string ConsultationName { get; set; }

        [Display(Name = "Խորհրդատվության արժեքը")]
        public double? ConsultationCost { get; set; }

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
        public DateTime? ReferralConsultationDate { get; set; }

    }
}