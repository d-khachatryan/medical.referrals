using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Medicalreferrals.Models
{
    [Table("vwInvocationDocument", Schema = "log")]
    public class InvocationDocumentLogItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ՀՀ")]
        public int InvocationDocumentLogId { get; set; }

        public int InvocationDocumentId { get; set; }
        public int? InvocationId { get; set; }

        
        [Display(Name = "Փաստաթղթի տեսակը")]
        public int? DocumentTypeId { get; set; }

        [Display(Name = "Փաստաթղթի անվանում")]
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