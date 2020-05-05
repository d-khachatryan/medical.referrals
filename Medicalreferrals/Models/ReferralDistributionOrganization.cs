using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medicalreferrals.Models
{
    public class ReferralDistributionOrganization
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReferralDistributionOrganizationId { get; set; }

        public int? ReferralDistributionId { get; set; }

        [Display(Name = "Կոդ")]
        public int? OrganizationId { get; set; }

        [Display(Name = "Նախատեսված ուղեգրերի քանակ")]
        public int? ReferralDistributionCount { get; set; }

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