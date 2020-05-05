using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Medicalreferrals.Models
{
    public class ReferralConsultation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReferralConsultationId { get; set; }

        public int? ReferralId { get; set; }

        [Display(Name = "Խորհրդատվության կոդը")]
        public string ConsultationCode { get; set; }

        [Display(Name = "Խորհրդատվության անվանումը")]
        public string ConsultationName { get; set; }

        [Display(Name = "Խորհրդատվության արժեքը")]
        public double? ConsultationCost { get; set; }

        public string Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? LogDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ամսաթիվ")]
        public DateTime? ReferralConsultationDate { get; set; }

        [NotMapped]
        public int? RecordStatus { get; set; }
    }
}