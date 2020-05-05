using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Medicalreferrals.Models
{
    public class InitiationType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Ուեգրման դիմումի տեսակի ID")]
        public int InitiationTypeId { get; set; }

        [Display(Name = "Ուեգրման դիմումի տեսակի կոդ")]
        public string InitiationTypeCode { get; set; }

        [Display(Name = "Ուեգրման դիմումի տեսակի անվանում")]
        public string InitiationTypeName { get; set; }
    }
}