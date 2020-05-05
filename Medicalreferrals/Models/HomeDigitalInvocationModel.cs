using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Medicalreferrals.Models
{
    public class HomeDigitalInvocationModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Հերթական համար")]
        public int InvocationId { get; set; }

        [Required(ErrorMessage = "Դաշտը պարտադիր է:")]
        [StringLength(50, ErrorMessage = "Դաշտը չի կարող պարունակել 50-ից ավել նիշեր:")]
        [Display(Name = "Անուն")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Դաշտը պարտադիր է:")]
        [StringLength(50, ErrorMessage = "Դաշտը չի կարող պարունակել 50-ից ավել նիշեր:")]
        [Display(Name = "Ազգանուն")]
        public string LastName { get; set; }

        [StringLength(50, ErrorMessage = "Դաշտը չի կարող պարունակել 50-ից ավել նիշեր:")]
        [Display(Name = "Հայրանուն")]
        public string PatronymicName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ծննդյան տարեթիվ")]
        [Required(ErrorMessage = "Դաշտը պարտադիր է:")]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "Մարզ")]
        [Required(ErrorMessage = "Դաշտը պարտադիր է:")]
        public int? RegionId { get; set; }

        [Display(Name = "Համայնք")]
        [Required(ErrorMessage = "Դաշտը պարտադիր է:")]
        public int? CommunityId { get; set; }

        [Display(Name = "Փողոց")]
        public string Street { get; set; }

        [Display(Name = "Տուն")]
        public string Home { get; set; }

        [Display(Name = "Բնակարան")]
        public string Room { get; set; }

        [Display(Name = "էլեկտրոնային փոստի հասցեն")]
        public string ResidentMail { get; set; }

        [Display(Name = "Դիմումի նպատակը")]
        [Required(ErrorMessage = "Դաշտը պարտադիր է:")]
        public int? InvocationPurposeId { get; set; }

        [Display(Name = "Կազմակերպություն")]
        [Required(ErrorMessage = "Դաշտը պարտադիր է:")]
        public int? OrganizationId { get; set; }

        [Display(Name = "Կարգավիճակ")]
        public int? InvocationStatusId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[Required(ErrorMessage = "Դաշտը պարտադիր է:")]
        public DateTime? InvocationDate { get; set; }

        public int? InitiationTypeId { get; set; }        
    }
}