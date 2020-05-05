using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medicalreferrals.Models
{
    public class ReferralOrderTemplate
    {
        [Key]
        [Display(Name = "Հերթագրման համար")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReferralOrderId { get; set; }

        public int? ReferralId { get; set; }

        
        [Display(Name = "Բավարարման ամսաթիվ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ConfirmationDate { get; set; }

        [Required(ErrorMessage = "Դաշտը պարտադիր է:")]
        [Display(Name = "Հիմնարկ")]
        public int? OrganizationId { get; set; }

        [Required(ErrorMessage = "Դաշտը պարտադիր է:")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Հերթագրման ամսաթիվ")]
        public DateTime? ReferralOrderDate { get; set; }

        [Required(ErrorMessage = "Դաշտը պարտադիր է:")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Հաստատման ամսաթիվ")]
        public DateTime? ConfirmOrderDate { get; set; }

        [Display(Name = "Վավերության ամսաթիվ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ValidityDate { get; set; }

        public int? ReferralOrderStatusId { get; set; }

    }
}