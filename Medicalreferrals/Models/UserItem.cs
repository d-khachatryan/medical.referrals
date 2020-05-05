using System;
using System.ComponentModel.DataAnnotations;

namespace Medicalreferrals.Models
{

    public class UserItem
    {
        //[Required(ErrorMessageResourceName = "User_Name_Required", ErrorMessageResourceType = typeof(Resources.Resources))]
        //[StringLength(100, ErrorMessageResourceName = "User_Name_Val", MinimumLength = 6, ErrorMessageResourceType = typeof(Resources.Resources))]
        [Display(Name = "Գործարկող")]
        public string UserName { get; set; }

        //[Required(ErrorMessageResourceName = "User_Email_Required", ErrorMessageResourceType = typeof(Resources.Resources))]
        //[EmailAddress(ErrorMessageResourceName = "User_Email_Val", ErrorMessageResourceType = typeof(Resources.Resources))]
        [Display(Name = "Էլ․ փոստի հասցե")]
        public string Email { get; set; }

        //[Required(ErrorMessageResourceName = "User_Password_Required", ErrorMessageResourceType = typeof(Resources.Resources))]
        //[StringLength(100, ErrorMessageResourceName = "User_Password_Val", MinimumLength = 6, ErrorMessageResourceType = typeof(Resources.Resources))]
        //[RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*(_|[^\\w])).+$", ErrorMessageResourceName = "User_Password_ValGlob", ErrorMessageResourceType = typeof(Resources.Resources))]
        //[DataType(DataType.Password)]
        [Display(Name = "Գաղտնաբառ")]
        public string Password { get; set; }

        //[DataType(DataType.Password)]
        [Display(Name = "Գաղտնաբառի հաստատում")]
        //[Compare("Password", ErrorMessageResourceName = "User_Password_Confirm", ErrorMessageResourceType = typeof(Resources.Resources))]
        public string ConfirmPassword { get; set; }

        [Key]
        public string Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PositionName { get; set; }

    }
}
