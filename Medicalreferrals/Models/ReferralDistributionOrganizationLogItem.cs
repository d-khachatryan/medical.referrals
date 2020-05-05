using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medicalreferrals.Models
{
    [Table("vwReferralDistributionOrganizationLog")]
    public class ReferralDistributionOrganizationLogItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReferralDistributionOrganizationLogId { get; set; }

        public int? ReferralDistributionOrganizationId { get; set; }

        public int? ReferralDistributionId { get; set; }

        public int? OrganizationId { get; set; }

        [Display(Name = "Կոդ")]
        public string OrganizationCode { get; set; }

        [Display(Name = "Հիմնարկ")]
        public string OrganizationName { get; set; }

        [Display(Name = "Նախատեսված ուղեգրերի քանակ")]
        public int? ReferralDistributionCount { get; set; }

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