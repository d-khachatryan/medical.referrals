using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Medicalreferrals.Models
{
    public class Diagnose
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Ախտորոշման ID")]
        public int DiagnoseId { get; set; }

        [Display(Name = "Ախտորոշման կոդ")]
        public string DiagnoseCode { get; set; }

        [Display(Name = "Ախտորոշման անուն")]
        public string DiagnoseName { get; set; }
    }
}