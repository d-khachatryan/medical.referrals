using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Medicalreferrals.Models
{
    public class Outcome
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Հիվանդության ելքի ID")]
        public int OutcomeId { get; set; }

        [Display(Name = "Հիվանդության ելքի կոդ")]
        public string OutcomeCode { get; set; }

        [Display(Name = "Հիվանդության ելքի անվանում")]
        public string OutcomeName { get; set; }
    }
}