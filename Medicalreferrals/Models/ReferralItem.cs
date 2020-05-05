using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Medicalreferrals.Models
{
    [Table("vwReferral")]
    public class ReferralItem
    {
        [Key]
        [Display(Name = "Հերթական համար")]
        public int ReferralId { get; set; }

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

        [Display(Name = "Անձը հաստատող փաստաթուղթի տեսակ")]
        public int? IdentificatorTypeId { get; set; }

        [Display(Name = "Անձը հաստատող փաստաթուղթ")]
        public string IdentificatorTypeName { get; set; }

        [Display(Name = "Սերիան և համարը")]
        public string Identificator { get; set; }

        [Display(Name = "Հեռախոսահամարը")]
        public string Phone { get; set; }

        [Display(Name = "էլեկտրոնային փոստի հասցեն")]
        public string ResidentMail { get; set; }

        [Display(Name = "Բնակության մարզ")]
        public int? ResidentRegionId { get; set; }

        [Display(Name = "Բնակության մարզ")]
        public string ResidentRegionName { get; set; }

        [Display(Name = "Համայնք")]
        public int? ResidentCommunityId { get; set; }

        [Display(Name = "Համայնք")]
        public string ResidentCommunityName { get; set; }

        [Display(Name = "Փողոց")]
        public string ResidentStreet { get; set; }

        [Display(Name = "Տուն")]
        public string ResidentHome { get; set; }

        [Display(Name = "Բնակարան")]
        public string ResidentRoom { get; set; }

        [Display(Name = "Հաշվառման մարզ")]
        public int? HabitantRegionId { get; set; }

        [Display(Name = "Հաշվառման մարզ")]
        public string HabitantRegionName { get; set; }

        [Display(Name = "Համայնք")]
        public int? HabitantCommunityId { get; set; }

        [Display(Name = "Համայնք")]
        public string HabitantCommunityName { get; set; }

        [Display(Name = "Փողոց")]
        public string HabitantStreet { get; set; }

        [Display(Name = "Տուն")]
        public string HabitantHome { get; set; }

        [Display(Name = "Բնակարան")]
        public string HabitantRoom { get; set; }

        [Display(Name = "Ուղեգրող մարմին (հանձնաժողով) բժշկական կազմակերպություն")]
        public int? ReferralOrganizationId { get; set; }

        [Display(Name = "Ուղեգրող մարմին (հանձնաժողով) բժշկական կազմակերպություն")]
        public string ReferralOrganizationName { get; set; }

        [Display(Name = "Ծածկագիր")]
        public string ReferralOrganizationCode { get; set; }

        [Display(Name = "Գործունեության վայրը")]
        public string ReferralOrganizationLocation { get; set; }

        [Display(Name = "Հեռախոսահամարը")]
        public string ReferralOrganizationPhone { get; set; }

        [Display(Name = "Նախնական ախտորոշումը")]
        public string PreliminaryDiagnose { get; set; }

        [Display(Name = "Ախտորոշման ճշտում հիվանդանոցային պայմաններում")]
        public bool? ReferralPurpose1 { get; set; }

        [Display(Name = "Բուժում հիվանդանոցային պայմաններում")]
        public bool? ReferralPurpose2 { get; set; }

        [Display(Name = "Հատուկ և դժվարամատչելի հետազոտություններ")]
        public bool? ReferralPurpose3 { get; set; }

        //[Display(Name = "")]
        public string ReferralPurpose3Description { get; set; }

        [Display(Name = "Առողջարանային բուժում")]
        public bool? ReferralPurpose4 { get; set; }

        [Display(Name = "Փորձաքննություն (բժշկական, դատաբժշկական, ռազմաբժշկական, նախազորակոչային, զորակոչային)")]
        public bool? ReferralPurpose5 { get; set; }

        [Display(Name = "Օրթեզավորում/կորսետավորում")]
        public bool? ReferralPurpose6 { get; set; }

        [Display(Name = "Այլ")]
        public bool? ReferralPurpose7 { get; set; }

        //[Display(Name = "")]
        public string ReferralPurpose7Description { get; set; }

        [Display(Name = "Սոցիալական փաթեթի շահառու ")]
        public bool? SocialBenefit { get; set; }

        [Display(Name = "հավաստագրի համարը - ")]
        public string SocialBenefitDescription { get; set; }

        [Display(Name = "Բուժող բժիշկ")]
        public int? PhysicianId { get; set; }

        [Display(Name = "Բուժող բժիշկ")]
        public string PhysicianName { get; set; }

        [Display(Name = "Ծածկագիրը")]
        public string PhysicianCode { get; set; }

        [Display(Name = "Ուղեգրի լրացման ամսաթիվ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ReferralDate { get; set; }

        [Display(Name = "Ուղեգրող մարմնի (հանձնաժողովի, բժշկական կազմակերպության) ղեկավար")]
        public string HeadName { get; set; }

        [Display(Name = "Հավելյալ տեղեկատվություն")]
        public string Comment { get; set; }

        public int? ReferralStatusId { get; set; }

        [Display(Name = "Կարգավիճակ")]
        public string ReferralStatusName { get; set; }
                
        [DataType(DataType.Date)]
        [Display(Name = "Համաձայնեցման ամսաթիվ")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ConformationDate { get; set; }
                
        [DataType(DataType.Date)]
        [Display(Name = "Հաստատման ամսաթիվ")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ConfirmationDate { get; set; }

        public int? InvocationId { get; set; }

        public string InvocationNumber { get; set; }

        [Display(Name = "Կցված ֆայլ")]
        public string DocumentURL { get; set; }

        public Guid? DocumentGuid { get; set; }

        public int? DiagnoseId { get; set; }

        public string DiagnoseName { get; set; }

        public int? OutcomeId { get; set; }

        public string OutcomeName { get; set; }

        [Display(Name = "Ծառայության մատուցման ա/թ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? StartDate { get; set; }

        [Display(Name = "Ծառայության մատուցման ա/թ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? TerminationDate { get; set; }

        public int? OrganizationId { get; set; }

        public string OrganizationCode { get; set; }
        public string OrganizationName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Ուղեգրի նախապատրաստման ա/թ")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? InitiationDate { get; set; }

        public string Id { get; set; }
        public DateTime? LogDate { get; set; }
        public string ConformationUserId { get; set; }
        public string ConfirmationUserId { get; set; }
        public string ServiceUserId { get; set; }
        public string UserName { get; set; }
        public string ConformationUserName { get; set; }
        public string ConfirmationUserName { get; set; }
        public string ServiceUserName { get; set; }

        public DateTime? ValidityDate { get; set; }

        [NotMapped]
        [Display(Name = "Հրահանգներ")]
        public string Commands { get; set; }

    }
}