
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medicalreferrals.Models
{
    
    public class OrganizationBudgetLine
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrganizationBudgetLineId { get; set; }

        [ForeignKey("Organization")]
        public int? OrganizationId { get; set; }
        public Organization Organization { get; set; }

        [Display(Name = "ՊՊ խմբի անվանում")]
        public int? BudgetLineId { get; set; }

        [Display(Name = "Հերթագրող")]
        public bool? IsOrderable { get; set; }

        [Display(Name = "Ուղեգրող")]
        public bool? IsReferrable { get; set; }

        [NotMapped]
        public int? RecordStatus { get; set; }

    }
}