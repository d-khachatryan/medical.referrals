using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medicalreferrals.Models
{
    public class Organization
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Հ/Հ")]
        public int OrganizationId { get; set; }

        [Display(Name = "Կոդ")]
        public string OrganizationCode { get; set; }

        [Display(Name = "Հիմնարկ")]
        public string OrganizationName { get; set; }

        [Display(Name = "Մարզ")]
        public int? RegionId { get; set; }

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

        [Display(Name = "Ուղեգրող հիմնարկ")]
        public bool? IsReferralOrganization { get; set; }

        [Display(Name = "Դիմում ընդունող հիմնարկ")]
        public bool? IsInvocationOrganization { get; set; }

        [Display(Name = "ՈՒղեգրի համարի սերիա")]
        public string ReferralNumberTemlate { get; set; }

        [Display(Name = "Հիմնարկի տեսակ")]
        public int? OrganizationTypeId { get; set; }

        [Display(Name = "Բյուջեի խմբեր")]
        public virtual ICollection<OrganizationBudgetLine> OrganizationBudgetLines { get; set; }
    }
}