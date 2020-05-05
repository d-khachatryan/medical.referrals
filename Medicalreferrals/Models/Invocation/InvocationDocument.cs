using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medicalreferrals.Models
{
    public class InvocationDocument
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InvocationDocumentId { get; set; }

        public int? InvocationId { get; set; }

        [Required(ErrorMessage = "Դաշտը պարտադիր է:")]
        [Display(Name = "Փաստաթղթի տեսակը")]
        public int? DocumentTypeId { get; set; }

        public string DocumentURL { get; set; }

        public Guid? DocumentGuid { get; set; }

        public string Id { get; set; }

        public DateTime? LogDate { get; set; }
    }
}