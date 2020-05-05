using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medicalreferrals.Models
{
    [Table("vwOrganizationBudgetLine")]
    public class OrganizationBudgetLineItem
    {
        [Key]
        public int OrganizationBudgetLineId { get; set; }

        [ForeignKey("Organization")]
        public int? OrganizationId { get; set; }
        public Organization Organization { get; set; }

        [Display(Name = "Կոդ")]
        public string OrganizationCode { get; set; }

        [Display(Name = "Հիմնարկ")]
        public string OrganizationName { get; set; }

        public int? BudgetLineId { get; set; }

        [Display(Name = "ՊՊ խմբի կոդ")]
        public string BudgetLineCode { get; set; }

        [Display(Name = "ՊՊ խմբի անվանում")]
        public string BudgetLineName { get; set; }

        [Display(Name = "Հերթագրող")]
        public bool? IsOrderable { get; set; }

        [Display(Name = "Ուղեգրող")]
        public bool? IsReferrable { get; set; }


    }
}