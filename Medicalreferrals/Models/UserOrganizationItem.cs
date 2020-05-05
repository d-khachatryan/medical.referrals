using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medicalreferrals.Models
{
    [Table("vwUserOrganization")]
    public class UserOrganizationItem
    {
        [Key]
        public int UserOrganizationId { get; set; }

        public string Id { get; set; }

        public int? OrganizationId { get; set; }

        [Display(Name = "Կոդ")]
        public string OrganizationCode { get; set; }

        [Display(Name = "Հիմնարկ")]
        public string OrganizationName { get; set; }

        [Display(Name = "Լիազորություն 1")]
        public bool? Psm01 { get; set; }

        [Display(Name = "Լիազորություն 2")]
        public bool? Psm02 { get; set; }

        [Display(Name = "Լիազորություն 3")]
        public bool? Psm03 { get; set; }
    }
}