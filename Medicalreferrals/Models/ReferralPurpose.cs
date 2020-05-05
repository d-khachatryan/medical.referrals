using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Medicalreferrals.Models
{
    public class ReferralPurpose
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Ուղեգրման հիմքի ID")]
        public int ReferralPurposeId { get; set; }

        [Display(Name = "Ուղեգրման հիմքի կոդ")]
        public string ReferralPurposeCode { get; set; }

        [Display(Name = "Ուղեգրման հիմքի անվանում")]
        public string ReferralPurposeName { get; set; }
    }
}