using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medicalreferrals.Models
{
    [Table("vwReferralOrder", Schema = "log")]
    public class ReferralOrderLogItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ՀՀ")]
        public int ReferralOrderLogId { get; set; }

        public int ReferralOrderId { get; set; }
        public int? ReferralId { get; set; }

        public int? OrganizationId { get; set; }

        [Display(Name = "Կազմակերպության անվանում")]
        public string OrganizationName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ամսաթիվ")]
        public DateTime? ReferralOrderDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ամսաթիվ")]
        public DateTime? ConfirmOrderDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ամսաթիվ")]
        public DateTime? ServiceDate { get; set; }

        public int? ReferralOrderStatusId { get; set; }

        [Display(Name = "Կազմակերպության անվանում")]
        public string ReferralOrderStatusName { get; set; }

        public string Id { get; set; }

        [Display(Name = "Գործարկող")]
        public string UserName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Փոփոխման իրականացման ամսաթիվ")]
        public DateTime? LogDate { get; set; }
    }
}