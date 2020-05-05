using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medicalreferrals.Models
{
    public class Invocation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Հերթական համար")]
        public int InvocationId { get; set; }

        [StringLength(50, ErrorMessage = "Դաշտը չի կարող պարունակել 50-ից ավել նիշեր:")]
        [Display(Name = "Անուն")]
        public string FirstName { get; set; }

        [StringLength(50, ErrorMessage = "Դաշտը չի կարող պարունակել 50-ից ավել նիշեր:")]
        [Display(Name = "Ազգանուն")]
        public string LastName { get; set; }

        [StringLength(50, ErrorMessage = "Դաշտը չի կարող պարունակել 50-ից ավել նիշեր:")]
        [Display(Name = "Հայրանուն")]
        public string PatronymicName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ծննդյան տարեթիվ")]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "Մարզ")]
        public int? RegionId { get; set; }

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

        [Display(Name = "Դիմումի նպատակը")]
        public int? InvocationPurposeId { get; set; }

        [Display(Name = "Կազմակերպություն")]
        public int? OrganizationId { get; set; }

        [Display(Name = "Կարգավիճակ")]
        public int? InvocationStatusId { get; set; }

        public DateTime? ConformationDate { get; set; }

        public DateTime? ConfirmationDate { get; set; }

        public string InvocationURL { get; set; }

        public Guid? InvocationGuid { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? InvocationDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? InitiationDate { get; set; }

        public int? InitiationTypeId { get; set; }

        public string ConformationUserId { get; set; }

        public string ConfirmationUserId { get; set; }

        public string Id { get; set; }

        public DateTime? LogDate { get; set; }

    }
}