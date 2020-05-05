using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Medicalreferrals.Models
{
    [Table("vwReferral", Schema = "log")]
    public class ReferralLogItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Հերթական համար")]
        public int ReferralId { get; set; }

        //[Display(Name = "Ուղեգրի համար")]
        //public string ReferralNumber { get; set; }

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

        [Display(Name = "Անձը հաստատող փաստաթուղթ")]
        public int? IdentificatorTypeId { get; set; }

        [Display(Name = "Անձը հաստատող փաստաթուղթ")]
        public string IdentificatorTypeName { get; set; }

        //[Required(ErrorMessage = "Դաշտը պարտադիր է:")]
        [Display(Name = "Սերիան և համարը")]
        public string Identificator { get; set; }

        [Display(Name = "Հեռախոսահամարը")]
        public string Phone { get; set; }

        //[Display(Name = "էլեկտրոնային փոստի հասցեն")]
        //public string ResidentMail { get; set; }

        [Display(Name = "Մարզ")]
        public int? ResidentRegionId { get; set; }

        [Display(Name = "Մարզ")]
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

        [Display(Name = "Մարզ")]
        public int? HabitantRegionId { get; set; }

        [Display(Name = "Մարզ")]
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

        [Display(Name = "Անվանում")]
        public int? ReferralOrganizationId { get; set; }

        [Display(Name = "Անվանում")]
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

        [Display(Name = " ")]
        public string ReferralPurpose3Description { get; set; }

        [Display(Name = "Առողջարանային բուժում")]
        public bool? ReferralPurpose4 { get; set; }

        [Display(Name = "Փորձաքննություն (բժշկական, դատաբժշկական, ռազմաբժշկական, նախազորակոչային, զորակոչային)")]
        public bool? ReferralPurpose5 { get; set; }

        [Display(Name = "Օրթեզավորում/կորսետավորում")]
        public bool? ReferralPurpose6 { get; set; }

        [Display(Name = "Այլ")]
        public bool? ReferralPurpose7 { get; set; }

        [Display(Name = " ")]
        public string ReferralPurpose7Description { get; set; }

        [Display(Name = "Սոցիալական փաթեթի շահառու ")]
        public bool? SocialBenefit { get; set; }

        [Display(Name = "(հավաստագրի համարը)")]
        public string SocialBenefitDescription { get; set; }

        [Display(Name = "Անուն")]
        public int? PhysicianId { get; set; }

        [Display(Name = "Անուն")]
        public string PhysicianName { get; set; }

        [Display(Name = "Ծածկագիրը")]
        public string PhysicianCode { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ուղեգրի լրացման ամսաթիվ")]
        public DateTime? ReferralDate { get; set; }

        [Display(Name = "Ուղեգրող մարմնի (հանձնաժողովի, բժշկական կազմակերպության) ղեկավար")]
        public string HeadName { get; set; }

        [Display(Name = "էլեկտրոնային փոստի հասցե")]
        public string ResidentMail { get; set; }

        [Display(Name = " ")]
        public string Comment { get; set; }

        [Display(Name = "Կարգավիճակ")]
        public int? ReferralStatusId { get; set; }

        [Display(Name = "Կարգավիճակ")]
        public string ReferralStatusName { get; set; }

        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Համաձայնեցման ա/թ")]
        public DateTime? ConformationDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Հաստատման ա/թ")]
        public DateTime? ConfirmationDate { get; set; }

        [Display(Name = "Դիմում")]
        public int? InvocationId { get; set; }

        [Display(Name = "Դիմումի համար")]
        public string InvocationNumber { get; set; }

        [Display(Name = "Կցված ֆայլ")]
        public string DocumentURL { get; set; }

        public Guid? DocumentGuid { get; set; }

        [Display(Name = "Ախտորոշում")]
        public int? DiagnoseId { get; set; }

        [Display(Name = "Ախտորոշում")]
        public string DiagnoseName { get; set; }

        [Display(Name = "Ելք")]
        public int? OutcomeId { get; set; }

        [Display(Name = "Ելք")]
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

        [Display(Name = "Կազմակերպության կոդ")]
        public string OrganizationCode { get; set; }

        [Display(Name = "Կազմակերպության անվանում")]
        public string OrganizationName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ընդունման ամսաթիվ")]
        public DateTime? InitiationDate { get; set; }

        [Display(Name = "Ուղեգրի համար")]
        public string ReferralNumber { get; set; }

        [Display(Name = "Համաձայնեցնողի ID")]
        public string ConformationUserId { get; set; }

        [Display(Name = "Հաստատողի ID")]
        public string ConfirmationUserId { get; set; }

        [Display(Name = "Իրացումը ձևակերպողի ID")]
        public string ServiceUserId { get; set; }

        [Display(Name = "ID")]
        public string Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Փոփոխման իրականացման ամսաթիվ")]
        public DateTime? LogDate { get; set; }

        [Display(Name = "Գործարկող")]
        public string UserName { get; set; }

        [Display(Name = "Համաձայնեցնող")]
        public string ConformationUserName { get; set; }

        [Display(Name = "Հաստատող")]
        public string ConfirmationUserName { get; set; }

        [Display(Name = "Իրացումը ձևակերպող")]
        public string ServiceUserName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Վավերականության ամսաթիվ")]
        public DateTime? ValidityDate { get; set; }
     }

}