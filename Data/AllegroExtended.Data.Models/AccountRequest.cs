namespace AllegroExtended.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using AllegroExtended.Common;
    using AllegroExtended.Data.Common.Models;

    public class AccountRequest : BaseModel<int>, IAuditInfo
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(GlobalConstants.UserNameMinLength)]
        [MaxLength(GlobalConstants.UserNameMaxLength)]
        public string UserName { get; set; }

        [MaxLength(200)]
        public string Remark { get; set; }

        [Required]
        public bool IsRead { get; set; }

        public int GroupId { get; set; }

        public virtual Group Gruop { get; set; }
    }
}
