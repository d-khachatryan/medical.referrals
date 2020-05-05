using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Medicalreferrals.Models
{
    public class ReferralExamination
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReferralExaminationId { get; set; }

        public int? ReferralId { get; set; }

        [Display(Name = "Հետազոտության կոդը")]
        public string ExaminationCode { get; set; }

        [Display(Name = "Հետազոտության անվանումը")]
        public string ExaminationName { get; set; }

        [Display(Name = "Հետազոտության քանակը")]
        public int? ExaminationCount { get; set; }

        [Display(Name = "Հետազոտության արժեքը")]
        public double? ExaminationCost { get; set; }

        public string Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? LogDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ամսաթիվ")]
        public DateTime? ReferralExaminationDate { get; set; }

        [NotMapped]
        public int? RecordStatus { get; set; }
    }
}