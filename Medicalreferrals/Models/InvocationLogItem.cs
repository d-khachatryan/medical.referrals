using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Medicalreferrals.Models
{
    [Table("vwInvocation", Schema = "log")]
    public class InvocationLogItem
    {
        [Key]
        [Display(Name = "Հերթական համար")]
        public int InvocationLogId { get; set; }
        
        [Display(Name = "Հերթական համար")]
        public int InvocationId { get; set; }

        [Display(Name = "Անուն")]
        public string FirstName { get; set; }

        [Display(Name = "Ազգանուն")]
        public string LastName { get; set; }

        [Display(Name = "Հայրանուն")]
        public string PatronymicName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
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

        [Display(Name = "Ծածկագիր")]
        public string OrganizationCode { get; set; }

        [Display(Name = "Կազմակերպություն")]
        public string OrganizationName { get; set; }

        [Display(Name = "Կարգավիճակ")]
        public int? InvocationStatusId { get; set; }

        [Display(Name = "Կարգավիճակ")]
        public string InvocationStatusName { get; set; }

        [Display(Name = "Համաձայնեցման ամսաթիվ")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ConformationDate { get; set; }

        [Display(Name = "Համաձայնեցում")]
        public string ConformationUserId { get; set; }

        [Display(Name = "Օգտվող")]
        public string UserName { get; set; }

        [Display(Name = "Հաստատման ամսաթիվ")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ConfirmationDate { get; set; }

        [Display(Name = "Հաստատում")]
        public string ConfirmationUserId { get; set; }

        [Display(Name = "Հաստատում")]
        public string ConfirmationUserName { get; set; }

        [Display(Name = "Փաստաթղթի հղումը")]
        public string InvocationURL { get; set; }

        [Display(Name = "Իդենտիֆիկատոր")]
        public Guid? InvocationGuid { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Դիմումի ներկայացման ա/թ")]
        public DateTime? InvocationDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Դիմումի կազմման ամսաթիվը")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? InitiationDate { get; set; }

        public int? InitiationTypeId { get; set; }

        [Display(Name = "Դիմումի տեսակը")]
        public string InitiationTypeName { get; set; }

        //[Display(Name = "Կարգավիճակ")]
        //public int? InvocationStatusTypeId { get; set; }
        //[Display(Name = "Կարգավիճակ")]
        //public string InvocationStatusTypeName { get; set; }

        public string Id { get; set; }

        //public string ConformationUserId { get; set; }

        //public string ConfirmationUserId { get; set; }

        [Display(Name = "Համաձայնեցնող")]
        public string ConformationUserName { get; set; }

        //[Display(Name = "Հաստատող")]
        //public string ConfirmationUserName { get; set; }

        //public string UserName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Փոփոխման իրականացմամ ամսաթիվ")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? LogDate { get; set; }

    }
}