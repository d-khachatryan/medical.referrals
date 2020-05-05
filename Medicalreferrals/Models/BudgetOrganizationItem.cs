using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medicalreferrals.Models
{
    [Table("vwBudgetOrganization")]
    public class BudgetOrganizationItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BudgetOrganizationId { get; set; }

        public int? BudgetId { get; set; }

        public int? OrganizationId { get; set; }

        [Display(Name = "Կոդ")]
        public string OrganizationCode { get; set; }

        [Display(Name = "Հիմնարկ")]
        public string OrganizationName { get; set; }

        [Display(Name = "Բյուջեի գումարը")]
        public double? BudgetCost { get; set; }

        [Display(Name = "Բյուջե 1")]
        public double? Budget1 { get; set; }

        [Display(Name = "Բյուջե 2")]
        public double? Budget2 { get; set; }

        [Display(Name = "Բյուջե 3")]
        public double? Budget3 { get; set; }

        public string Id { get; set; }

        public string UserName { get; set; }

        public int? BudgetLineId { get; set; }

        [Display(Name = "ՊՊ խմբի կոդ")]
        public string BudgetLineCode { get; set; }

        [Display(Name = "ՊՊ խմբի անվանում")]
        public string BudgetLineName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ամսաթիվ")]
        public DateTime? ChangeDate { get; set; }

        public int? ChangeBaseId { get; set; }

        public string ChangeBaseCode { get; set; }

        [Display(Name = "Փոփոխության հիմք")]
        public string ChangeBaseName { get; set; }
    }
}