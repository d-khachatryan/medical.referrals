using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Medicalreferrals.Models
{
    [Table("vwReferralDocument")]
    public class ReferralDocumentItem
    {
        [Key]
        public int ReferralDocumentId { get; set; }

        public int? ReferralId { get; set; }

        public int? DocumentTypeId { get; set; }
        [Display(Name = "Փաստաթղթի տեսակը")]
        public string DocumentTypeName { get; set; }
        [Display(Name = "Կցված ֆայլ")]
        public string DocumentURL { get; set; }

        public Guid? DocumentGuid { get; set; }
    }
}