namespace AllegroExtended.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AllegroExtended.Data.Common.Models;

    public class Group : BaseModel<int>, IAuditInfo
    {
        public Group()
        {
            this.Requests = new HashSet<AccountRequest>();
            this.Users = new HashSet<ApplicationUser>();
            this.Permissions = new HashSet<Permission>();
        }

        [MinLength(2)]
        [MaxLength(20)]
        public string Name { get; set; }

        public virtual ICollection<AccountRequest> Requests { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }

        public virtual ICollection<Permission> Permissions { get; set; }
    }
}
