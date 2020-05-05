using System;
using System.ComponentModel.DataAnnotations;

namespace Medicalreferrals.Models
{
    public class InvocationDocumentTemplate
    {
        [Key]
        public int InvocationDocumentId { get; set; }

        public int? InvocationId { get; set; }

        [Required(ErrorMessage = "Դաշտը պարտադիր է:")]
        [Display(Name = "Փաստաթղթի տեսակը")]
        public int? DocumentTypeId { get; set; }

        public Guid? DocumentGuid { get; set; }
    }
}