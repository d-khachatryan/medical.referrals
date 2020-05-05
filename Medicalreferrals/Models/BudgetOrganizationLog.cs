using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medicalreferrals.Models
{
    public class BudgetOrganizationLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BudgetOrganizationLogId { get; set; }

        public int? BudgetOrganizationId { get; set; }

        public int? BudgetId { get; set; }

        public int? OrganizationId { get; set; }

        public double? BudgetCost { get; set; }

        public double? Budget1 { get; set; }

        public double? Budget2 { get; set; }

        public double? Budget3 { get; set; }

        public string Id { get; set; }

        public int? BudgetLineId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ամսաթիվ")]
        public DateTime? ChangeDate { get; set; }

        public int? ChangeBaseId { get; set; }

    }
}