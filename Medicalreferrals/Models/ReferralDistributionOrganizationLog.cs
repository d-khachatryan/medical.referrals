using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medicalreferrals.Models
{
    public class ReferralDistributionOrganizationLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReferralDistributionOrganizationLogId { get; set; }

        public int? ReferralDistributionOrganizationId { get; set; }

        public int? ReferralDistributionId { get; set; }

        public int? OrganizationId { get; set; }

        public int? ReferralDistributionCount { get; set; }

        public string Id { get; set; }

        public int? BudgetLineId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ամսաթիվ")]
        public DateTime? ChangeDate { get; set; }

        public int? ChangeBaseId { get; set; }

    }
}