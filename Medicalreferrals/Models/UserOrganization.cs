using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medicalreferrals.Models
{
    public class UserOrganization
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserOrganizationId { get; set; }

        public string Id { get; set; }

        [Display(Name = "Հիմնարկ")]
        public int? OrganizationId { get; set; }

        [Display(Name = "Լիազորություն 1")]
        public bool? Psm01 { get; set; }

        [Display(Name = "Լիազորություն 2")]
        public bool? Psm02 { get; set; }

        [Display(Name = "Լիազորություն 3")]
        public bool? Psm03 { get; set; }
    }
}