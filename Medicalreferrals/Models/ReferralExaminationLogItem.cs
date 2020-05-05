using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medicalreferrals.Models
{
    [Table("vwReferralExamination", Schema = "log")]
    public class ReferralExaminationLogItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ՀՀ")]
        public int ReferralExaminationLogId { get; set; }

        public int ReferralExaminationId { get; set; }
        public int? ReferralId { get; set; }

        [Display(Name = "Հետազոտության կոդը")]
        public string ExaminationCode { get; set; }

        [Display(Name = "Հետազոտության անվանումը")]
        public string ExaminationName { get; set; }

        [Display(Name = "Հետազոտության արժեքը")]
        public double? ExaminationCost { get; set; }

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
        public DateTime? ReferralExaminationDate { get; set; }
    }
}