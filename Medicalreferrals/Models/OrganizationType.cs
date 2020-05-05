using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medicalreferrals.Models
{
    public class OrganizationType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Հ/Հ")]
        public int OrganizationTypeId { get; set; }

        [Display(Name = "Կոդ")]
        public string OrganizationTypeCode { get; set; }

        [Display(Name = "Հիմնարկի տեսակ")]
        public string OrganizationTypeName { get; set; }

        [Display(Name = "Բյուջե 1")]
        public double? Budget1 { get; set; }

        [Display(Name = "Բյուջե 2")]
        public double? Budget2 { get; set; }

        [Display(Name = "Բյուջե 3")]
        public double? Budget3 { get; set; }
    }
}