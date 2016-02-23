namespace AllegroExtended.Web.Areas.Administration.ViewModels
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    using AllegroExtended.Common;
    using AllegroExtended.Data.Models;

    public class UserViewModel
    {
        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("Username")]
        [MinLength(GlobalConstants.UserNameMinLength)]
        [MaxLength(GlobalConstants.UserNameMaxLength)]
        public string UserName { get; set; }

        [Required]
        public int Group { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Password do not match!")]
        public string ConfirmPassword { get; set; }
    }
}