using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medicalreferrals.Models
{
    [Table("vwInvocationDocument")]
    public class InvocationDocumentItem
    {
        [Key]
        public int InvocationDocumentId { get; set; }

        public int? InvocationId { get; set; }

        public int? DocumentTypeId { get; set; }
        [Display(Name = "Փաստաթղթի տեսակը")]
        public string DocumentTypeName { get; set; }
        [Display(Name = "Կցված ֆայլ")]
        public string DocumentURL { get; set; }

        public Guid? DocumentGuid { get; set; }
    }
}