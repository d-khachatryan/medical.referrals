using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Medicalreferrals.Models
{
    [Table("vwBudgetLine")]
    public class BudgetLineItem
    {
        [Key]
        public int BudgetLineId { get; set; }

        public string BudgetLineCode { get; set; }

        public string BudgetLineName { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? TerminationDate { get; set; }


    }
}