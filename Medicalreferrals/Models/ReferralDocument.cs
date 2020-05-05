using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medicalreferrals.Models
{
    public class ReferralDocument
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReferralDocumentId { get; set; }

        public int? ReferralId { get; set; }
        [Display(Name = "Փաստաթղթի տեսակը")]
        public int? DocumentTypeId { get; set; }

        public string DocumentURL { get; set; }

        public Guid? DocumentGuid { get; set; }
    }
}