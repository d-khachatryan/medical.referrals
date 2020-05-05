using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Medicalreferrals.Models
{
    [Table("vwAspNetUserRoles")]
    public class UserRoleItem
    {
        [Column(Order = 0), Key]
        public string UserId { get; set; }

        [Column(Order = 1), Key]
        [Display(Name = "Դեր")]
        public string RoleId { get; set; }

        [Display(Name = "Անվանում")]
        public string Name { get; set; }
    }
}