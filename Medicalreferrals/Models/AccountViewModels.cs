using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Medicalreferrals.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = "Մուտքանուն դաշտը պարտադիր է")]
        [Display(Name = "Մուտքանուն")]
        //[EmailAddress]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Գաղտնաբառ դաշտը պարտադիր է")]
        [DataType(DataType.Password)]
        [Display(Name = "Գաղտնաբառ")]
        public string Password { get; set; }

        [Display(Name = "Հիշել ինձ")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PositionName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "Դաշտը պարտադիր է")]
        [EmailAddress(ErrorMessage = "Էլ․ փոստի ֆորմատը ճիշտ չէ")]
        [Display(Name = "Էլ․ փոստ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Դաշտը պարտադիր է")]
        [StringLength(100, ErrorMessage = "{0}ը պետք է կազմված լինի նվազագույնը {2} նիշից", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Գաղտնաբառ")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Գաղտնաբառի հաստատում")]
        [Compare("Password", ErrorMessage = "Գաղտնաբառը և հաստատումը չեն համընկնում")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required (ErrorMessage = "Դաշտը պարտադիր է")]
        [EmailAddress(ErrorMessage = "Էլ․ փոստի ֆորմատը ճիշտ չէ")]
        [Display(Name = "Էլ․ փոստ")]
        public string Email { get; set; }
    }
}
