using System;
using System.ComponentModel.DataAnnotations;

namespace Medicalreferrals.Models
{
    public class InvocationTemplate
    {
        [Key]
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

        [Required(ErrorMessage = "Դաշտը պարտադիր է:")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ծննդյան տարեթիվ")]
        public DateTime? BirthDate { get; set; }

        [Required(ErrorMessage = "Դաշտը պարտադիր է:")]
        [Display(Name = "Մարզ")]
        public int? RegionId { get; set; }

        [Required(ErrorMessage = "Դաշտը պարտադիր է:")]
        [Display(Name = "Համայնք")]
        public int? CommunityId { get; set; }

        [Display(Name = "Փողոց")]
        public string Street { get; set; }

        [Display(Name = "Տուն")]
        public string Home { get; set; }

        [Display(Name = "Բնակարան")]
        public string Room { get; set; }

        [Display(Name = "էլեկտրոնային փոստի հասցեն")]
        public string ResidentMail { get; set; }

        [Required(ErrorMessage = "Դաշտը պարտադիր է:")]
        [Display(Name = "Դիմումի նպատակը")]
        public int? InvocationPurposeId { get; set; }

        [Required(ErrorMessage = "Դաշտը պարտադիր է:")]
        [Display(Name = "Կազմակերպություն")]
        public int? OrganizationId { get; set; }

        }
}