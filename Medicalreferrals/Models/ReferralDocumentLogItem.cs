using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medicalreferrals.Models
{
    [Table("vwReferralDocument", Schema = "log")]
    public class ReferralDocumentLogItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ՀՀ")]
        public int ReferralDocumentLogId { get; set; }

        public int ReferralDocumentId { get; set; }
        public int? ReferralId { get; set; }

        [Display(Name = "Փաստաթղթի տեսակը")]
        public int? DocumentTypeId { get; set; }

        [Display(Name = "Փաստաթղթի տեսակը")]
        public string DocumentTypeName { get; set; }

        [Display(Name = "Փաստաթղթի հղումը")]
        public string DocumentURL { get; set; }

        [Display(Name = "Իդենտիֆիկատոր")]
        public Guid? DocumentGuid { get; set; }
        public string Id { get; set; }

        [Display(Name = "Գործարկող")]
        public string UserName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Փոփոխման իրականացմամ ամսաթիվ")]
        public DateTime? LogDate { get; set; }
    }
}