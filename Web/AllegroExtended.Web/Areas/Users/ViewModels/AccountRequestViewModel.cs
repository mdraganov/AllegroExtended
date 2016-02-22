namespace AllegroExtended.Web.Areas.Users.ViewModels
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    using AllegroExtended.Common;

    public class AccountRequestViewModel
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
        [MinLength(2)]
        [MaxLength(200)]
        public string Department { get; set; }

        [MaxLength(200)]
        [DataType(DataType.MultilineText)]
        public string Remark { get; set; }
    }
}