using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medicalreferrals.Models
{
    [Table("vwOrganization")]
    public class OrganizationItem
    {
        [Key]
        [Display(Name = "Հ/Հ")]
        public int OrganizationId { get; set; }

        [Display(Name = "Կոդ")]
        public string OrganizationCode { get; set; }

        [Display(Name = "Հիմնարկ")]
        public string OrganizationName { get; set; }

        public int? RegionId { get; set; }

        [Display(Name = "Մարզ")]
        public string RegionName { get; set; }

        [Display(Name = "ՀՎՀՀ")]
        public string TinNumber { get; set; }

        [Display(Name = "Բանկ")]
        public string BankName { get; set; }

        [Display(Name = "Հաշվեհամար")]
        public string BankAccountNumber { get; set; }

        [Display(Name = "Վայրը")]
        public string OrganizationLocation { get; set; }

        [Display(Name = "Ղեկավար")]
        public string HeadName { get; set; }

        [Display(Name = "Հեռախոս")]
        public string Phone { get; set; }

        [Display(Name = "Էլ․ փոստի հասցե")]
        public string Mail { get; set; }

        public bool? IsReferralOrganization { get; set; }
        public bool? IsInvocationOrganization { get; set; }
        public string ReferralNumberTemlate { get; set; }

        public int? OrganizationTypeId { get; set; }

        [Display(Name = "Հիմնարկի տեսակ")]
        public string OrganizationTypeName { get; set; }
    }
}