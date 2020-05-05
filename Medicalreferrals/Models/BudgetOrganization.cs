using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medicalreferrals.Models
{
    public class BudgetOrganization
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BudgetOrganizationId { get; set; }

        public int? BudgetId { get; set; }

        [Display(Name = "Կոդ")]
        public int? OrganizationId { get; set; }

        [Display(Name = "Բյուջեի գումարը")]
        public double? BudgetCost { get; set; }

        [Display(Name = "Բյուջե 1")]
        public double? Budget1 { get; set; }

        [Display(Name = "Բյուջե 2")]
        public double? Budget2 { get; set; }

        [Display(Name = "Բյուջե 3")]
        public double? Budget3 { get; set; }

        public string Id { get; set; }

        [Display(Name = "ՊՊ խմբի կոդ")]
        public int? BudgetLineId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ամսաթիվ")]
        public DateTime? ChangeDate { get; set; }

        [Display(Name = "Փոփոխության հիմք")]
        public int? ChangeBaseId { get; set; }

    }
}