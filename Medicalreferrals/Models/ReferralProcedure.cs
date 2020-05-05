using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Medicalreferrals.Models
{
    public class ReferralProcedure
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReferralProcedureId { get; set; }

        public int? ReferralId { get; set; }

        [Display(Name = "Պրոցեդուրայի կոդը")]
        public string ProcedureCode { get; set; }

        [Display(Name = "Պրոցեդուրայի անվանումը")]
        public string ProcedureName { get; set; }

        [Display(Name = "Պրոցեդուրայի քանակը")]
        public int? ProcedureCount { get; set; }

        [Display(Name = "Պրոցեդուրայի արժեքը")]
        public double? ProcedureCost { get; set; }

        public string Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? LogDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ամսաթիվ")]
        public DateTime? ReferralProcedureDate { get; set; }

        [NotMapped]
        public int? RecordStatus { get; set; }
    }
}