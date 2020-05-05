using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Medicalreferrals.Models
{
    public class ReferralOrderInput
    {
        [Key]
        [Required(ErrorMessage = "Դաշտը պարտադիր է:")]
        [Display(Name = "Ուղեգրի համար")]
        public string ReferralNumber { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Հաստատման ամսաթիվ")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Դաշտը պարտադիր է:")]
        public DateTime? ConfirmationDate { get; set; }

        public string ReferralOrderStatusName { get; set; }

    }
}