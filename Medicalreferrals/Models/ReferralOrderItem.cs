using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medicalreferrals.Models
{
    [Table("vwReferralOrder")]
    public class ReferralOrderItem
    {
        [Key]
        [Display(Name = "Հերթագրման համար")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReferralOrderId { get; set; }

        public int? ReferralId { get; set; }

        [Display(Name = "Ուղեգրի համար")]
        public string ReferralNumber { get; set; }

        [Display(Name = "Անուն")]
        public string FirstName { get; set; }

        [Display(Name = "Ազգանուն")]
        public string LastName { get; set; }

        [Display(Name = "Հայրանուն")]
        public string PatronymicName { get; set; }

        [Display(Name = "Ծննդյան տարեթիվ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "Սերիան և համարը")]
        public string Identificator { get; set; }

        //[Display(Name = "Հիմնարկ")]
        public int? ReferralStatusId { get; set; }

        //[Display(Name = "Հիմնարկ")]
        public int? InvocationId { get; set; }

        [Display(Name = "Բավարարման ամսաթիվ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ConfirmationDate { get; set; }

        [Display(Name = "Հիմնարկ")]
        public int? OrganizationId { get; set; }

        [Display(Name = "Հիմնարկի Կոդ")]
        public string OrganizationCode { get; set; }

        [Display(Name = "Հիմնարկ")]
        public string OrganizationName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Հերթագրման ամսաթիվ")]
        public DateTime? ReferralOrderDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Հաստատման ամսաթիվ")]
        public DateTime? ConfirmOrderDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ծառայության մատուցման ամսաթիվ")]
        public DateTime? ServiceDate { get; set; }

        //[Display(Name = "Հիմնարկ")]
        public int? ReferralOrderStatusId { get; set; }

        [Display(Name = "Կարգավիճակ")]
        public string ReferralOrderStatusName { get; set; }

        public string ConfirmationUserId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Հաստատման ամսաթիվ")]
        public DateTime? ReferralOrderConfirmationDate { get; set; }

        public string Id { get; set; }

        public DateTime? LogDate { get; set; }

        [Display(Name = "Վավերության ամսաթիվ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ValidityDate { get; set; }

    }
}