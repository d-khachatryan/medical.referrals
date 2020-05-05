using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Medicalreferrals.Models
{
    public class ResponseInfo
    {
        [Key]
        [Display(Name = "Հերթական համար")]
        public int InvocationId { get; set; }

        [Display(Name = "Անուն")]
        public string FirstName { get; set; }

        [Display(Name = "Ազգանուն")]
        public string LastName { get; set; }

        [Display(Name = "Հայրանուն")]
        public string PatronymicName { get; set; }

        [Display(Name = "Ծննդյան տարեթիվ")]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "Բնակության մարզ")]
        public int? RegionId { get; set; }

        [Display(Name = "Բնակության մարզ")]
        public string RegionName { get; set; }

        [Display(Name = "Համայնք")]
        public int? CommunityId { get; set; }

        [Display(Name = "Համայնք")]
        public string CommunityName { get; set; }

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

        [Display(Name = "Դիմումի նպատակը")]
        public string InvocationPurposeName { get; set; }

        [Display(Name = "Կազմակերպություն")]
        public int? OrganizationId { get; set; }

        [Display(Name = "Կազմակերպություն")]
        public string OrganizationName { get; set; }

        [Display(Name = "Ծածկագիր")]
        public string OrganizationCode { get; set; }

        [Display(Name = "Կարգավիճակ")]
        public int? InvocationStatusId { get; set; }

        [Display(Name = "Կարգավիճակ")]
        public string InvocationStatusName { get; set; }

        [Display(Name = "Համաձայնեցման ամսաթիվ")]
        public DateTime? ConformationDate { get; set; }

        [Display(Name = "Հաստատման ամսաթիվ")]
        public DateTime? ConfirmationDate { get; set; }

        public string InvocationNumber { get; set; }

        public string InvocationURL { get; set; }

        public Guid? InvocationGuid { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? InvocationDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Դիմումի կազմման ամսաթիվը")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? InitiationDate { get; set; }

        public int? InitiationTypeId { get; set; }

        public string InitiationTypeName { get; set; }

        [Display(Name = "Կարգավիճակ")]
        public int? InvocationStatusTypeId { get; set; }

        [Display(Name = "Կարգավիճակ")]
        public string InvocationStatusTypeName { get; set; }


    }
}