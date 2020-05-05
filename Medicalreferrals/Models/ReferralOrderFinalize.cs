using System;
using System.ComponentModel.DataAnnotations;

namespace Medicalreferrals.Models
{
    public class ReferralOrderFinalize
    {
        [Key]
        public int? ReferralId { get; set; }

        [Required(ErrorMessage = "Դաշտը պարտադիր է:")]
        [Display(Name = "Ուղեգրի համար")]
        public string ReferralNumber { get; set; }

        //[DataType(DataType.Date)]
        [Display(Name = "Հաստատման ամսաթիվ")]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[Required(ErrorMessage = "Դաշտը պարտադիր է:")]
        public string ConfirmationDate { get; set; }

        public string ValidityDate { get; set; }

        [Required(ErrorMessage = "Դաշտը պարտադիր է:")]
        [Display(Name = "Հիմնարկ")]
        public int? OrganizationId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ամսաթիվ")]
        [Required(ErrorMessage = "Դաշտը պարտադիր է:")]
        public DateTime? ReferralOrderDate { get; set; }

        [Display(Name = "Անուն")]
        public string FirstName { get; set; }

        [Display(Name = "Ազգանուն")]
        public string LastName { get; set; }

        [Display(Name = "Հայրանուն")]
        public string PatronymicName { get; set; }

        [Display(Name = "Ծննդյան տարեթիվ")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string BirthDate { get; set; }
        
        [Display(Name = "Սերիան և համարը")]
        public string Identificator { get; set; }

        public string ReferralOrderStatusName { get; set; }

        [Display(Name = "Բնակության մարզ")]
        public string ResidentRegionName { get; set; }

        [Display(Name = "Համայնք")]
        public string ResidentCommunityName { get; set; }

        [Display(Name = "Փողոց")]
        public string ResidentStreet { get; set; }

        [Display(Name = "Տուն")]
        public string ResidentHome { get; set; }

        [Display(Name = "Բնակարան")]
        public string ResidentRoom { get; set; }

        [Display(Name = "էլեկտրոնային փոստ")]
        public string ResidentMail { get; set; }

        [Display(Name = "Հեռախոսահամարը")]
        public string Phone { get; set; }

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
    }
}