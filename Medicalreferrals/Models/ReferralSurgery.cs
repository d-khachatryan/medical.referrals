using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Medicalreferrals.Models
{
    public class ReferralSurgery
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReferralSurgeryId { get; set; }

        public int? ReferralId { get; set; }

        [Display(Name = "Միջամտության կոդը")]
        public string SurgeryCode { get; set; }

        [Display(Name = "Միջամտության անվանումը")]
        public string SurgeryName { get; set; }

        [Display(Name = "Միջամտության քանակը")]
        public int? SurgeryCount { get; set; }

        [Display(Name = "Միջամտության արժեքը")]
        public double? SurgeryCost { get; set; }

        public string Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? LogDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ամսաթիվ")]
        public DateTime? ReferralSurgeryDate { get; set; }

        [NotMapped]
        public int? RecordStatus { get; set; }
    }
}