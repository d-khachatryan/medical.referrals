using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Medicalreferrals.Models
{
    public class ReferralTemplate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Հերթական համար")]
        public int ReferralId { get; set; }

        [Required(ErrorMessage = "Դաշտը պարտադիր է:")]
        [StringLength(50, ErrorMessage = "Դաշտը չի կարող պարունակել 50-ից ավել նիշեր:")]
        [Display(Name = "Անուն")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Դաշտը պարտադիր է:")]
        [StringLength(50, ErrorMessage = "Դաշտը չի կարող պարունակել 50-ից ավել նիշեր:")]
        [Display(Name = "Ազգանուն")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Դաշտը պարտադիր է:")]
        [StringLength(50, ErrorMessage = "Դաշտը չի կարող պարունակել 50-ից ավել նիշեր:")]
        [Display(Name = "Հայրանուն")]
        public string PatronymicName { get; set; }

        [Required(ErrorMessage = "Դաշտը պարտադիր է:")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ծննդյան տարեթիվ")]
        public DateTime? BirthDate { get; set; }

        [Required(ErrorMessage = "Դաշտը պարտադիր է:")]
        [Display(Name = "Անձը հաստատող փաստաթուղթ")]
        public int? IdentificatorTypeId { get; set; }

        [Required(ErrorMessage = "Դաշտը պարտադիր է:")]
        [StringLength(20, ErrorMessage = "Դաշտը չի կարող պարունակել 20-ից ավել նիշեր:")]
        [Display(Name = "Սերիան և համարը")]
        public string Identificator { get; set; }

        [Required(ErrorMessage = "Դաշտը պարտադիր է:")]
        [Display(Name = "Հեռախոսահամարը")]
        public string Phone { get; set; }

        [Display(Name = "էլեկտրոնային փոստի հասցեն")]
        public string ResidentMail { get; set; }

        [Required(ErrorMessage = "Դաշտը պարտադիր է:")]
        [Display(Name = "Մարզ")]
        public int? ResidentRegionId { get; set; }

        [Required(ErrorMessage = "Դաշտը պարտադիր է:")]
        [Display(Name = "Համայնք")]
        public int? ResidentCommunityId { get; set; }

        [Display(Name = "Փողոց")]
        public string ResidentStreet { get; set; }

        [Display(Name = "Տուն")]
        public string ResidentHome { get; set; }

        [Display(Name = "Բնակարան")]
        public string ResidentRoom { get; set; }

        [Required(ErrorMessage = "Դաշտը պարտադիր է:")]
        [Display(Name = "Մարզ")]
        public int? HabitantRegionId { get; set; }

        [Required(ErrorMessage = "Դաշտը պարտադիր է:")]
        [Display(Name = "Համայնք")]
        public int? HabitantCommunityId { get; set; }

        [Display(Name = "Փողոց")]
        public string HabitantStreet { get; set; }

        [Display(Name = "Տուն")]
        public string HabitantHome { get; set; }

        [Display(Name = "Բնակարան")]
        public string HabitantRoom { get; set; }

        [Required(ErrorMessage = "Դաշտը պարտադիր է:")]
        [Display(Name = "Ուղեգրող կազմակերպության անվանում")]
        public int? ReferralOrganizationId { get; set; }

        [Display(Name = "Կոդ")]
        public string ReferralOrganizationCode { get; set; }

        [Display(Name = "Գործունեության վայր")]
        public string ReferralOrganizationLocation { get; set; }

        [Display(Name = "Հեռախոսահամար")]
        public string ReferralOrganizationPhone { get; set; }

        [Required(ErrorMessage = "Դաշտը պարտադիր է:")]
        [Display(Name = "Նախնական ախտորոշում")]
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

        [Display(Name = "(հավաստագրի համար)")]
        public string SocialBenefitDescription { get; set; }

        [Required(ErrorMessage = "Դաշտը պարտադիր է:")]
        [Display(Name = "Բժշկի անուն ազգանուն")]
        public int? PhysicianId { get; set; }

        [Display(Name = "Կոդ")]
        public string PhysicianCode { get; set; }

        [Required(ErrorMessage = "Դաշտը պարտադիր է:")]
        [Display(Name = "Ղեկավարի անունը, ազգանունը")]
        public string HeadName { get; set; }

        [Display(Name = " ")]
        public string Comment { get; set; }

        [Display(Name = "Դիմում")]
        public int? InvocationId { get; set; }

    }

}