using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medicalreferrals.Models
{
    public class DocumentType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Կցվող փաստաթղթի տեսակի ID")]
        public int DocumentTypeId { get; set; }

        [Display(Name = "Կցվող փաստաթղթի տեսակի կոդ")]
        public string DocumentTypeCode { get; set; }

        [Display(Name = "Կցվող փաստաթղթի տեսակի անվանում")]
        public string DocumentTypeName { get; set; }
    }
}