using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medicalreferrals.Models
{
    [Table("vwOrganizationReferralStore")]
    public class OrganizationReferralStoreItem
    {
        [Key]
        public int OrganizationReferralStoreId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Սկզբնական ա/թ")]
        public DateTime? StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Վերջնական ա/թ")]
        public DateTime? TerminationDate { get; set; }

        [Display(Name = "Դիմում")]
        public int? StoreCount { get; set; }

        public int? OrganizationId { get; set; }

        public string OrganizationCode { get; set; }

        public string OrganizationName { get; set; }
    }
}