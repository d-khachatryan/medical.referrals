using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Medicalreferrals.Models
{
    public class HomePaperInvocationModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Հերթական համար")]
        public int InvocationId { get; set; }

        [Display(Name = "էլեկտրոնային փոստի հասցեն")]
        public string ResidentMail { get; set; }

        [Display(Name = "Դիմումի նպատակը")]
        [Required(ErrorMessage = "Դաշտը պարտադիր է:")]
        public int? InvocationPurposeId { get; set; }

        [Display(Name = "Կազմակերպություն")]
        [Required(ErrorMessage = "Դաշտը պարտադիր է:")]
        public int? OrganizationId { get; set; }

        [Display(Name = "Կարգավիճակ")]
        public int? InvocationStatusId { get; set; }

        public string InvocationURL { get; set; }

        public Guid? InvocationGuid { get; set; }
        
    }
}