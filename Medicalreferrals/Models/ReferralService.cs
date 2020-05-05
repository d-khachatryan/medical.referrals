using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medicalreferrals.Models
{
    public class ReferralService
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReferralServiceId { get; set; }

        public int? ReferralId { get; set; }

        [Display(Name = "Ծառայության կոդը")]
        public string ServiceCode { get; set; }

        [Display(Name = "Ծառայության անվանումը")]
        public string ServiceName { get; set; }

        [Display(Name = "Ծառայության քանակը")]
        public int? ServiceCount { get; set; }

        [Display(Name = "Ծառայության արժեքը")]
        public double? ServiceCost { get; set; }

        public string Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? LogDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ամսաթիվ")]
        public DateTime? ReferralServiceDate { get; set; }

        [NotMapped]
        public int? RecordStatus { get; set; }

    }
}