using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Medicalreferrals.Models
{
    public class IdentificatorType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Ա.Հ.Փ.-ի տեսակի ID")]
        public int IdentificatorTypeId { get; set; }

        [Display(Name = "Ա.Հ.Փ.-ի տեսակի կոդ")]
        public string IdentificatorTypeCode { get; set; }

        [Display(Name = "Ա.Հ.Փ-ի տեսակի անվանում")]
        public string IdentificatorTypeName { get; set; }
    }
}