using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Medicalreferrals.Models
{
    public class BudgetLine
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ՊՊ խմբի ID")]
        public int BudgetLineId { get; set; }

        [Display(Name = "ՊՊ խմբի կոդ")]
        public string BudgetLineCode { get; set; }

        [Display(Name = "ՊՊ խմբի անվանում")]
        public string BudgetLineName { get; set; }

        [Display(Name = "Սկիզբ")]
        public DateTime? StartDate { get; set; }

        [Display(Name = "Ավարտ")]
        public DateTime? TerminationDate { get; set; }
    }
}