using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medicalreferrals.Models
{
    [Table("vwReferralProcedure", Schema = "log")]
    public class ReferralProcedureLogItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ՀՀ")]
        public int ReferralProcedureLogId { get; set; }

        public int ReferralProcedureId { get; set; }
        public int? ReferralId { get; set; }

        [Display(Name = "Պրոցեդուրայի կոդը")]
        public string ProcedureCode { get; set; }

        [Display(Name = "Պրոցեդուրայի անվանումը")]
        public string ProcedureName { get; set; }

        [Display(Name = "Պրոցեդուրայի արժեքը")]
        public double? ProcedureCost { get; set; }

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
        public DateTime? ReferralProcedureDate { get; set; }
    }
}