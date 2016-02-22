namespace AllegroExtended.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using AllegroExtended.Data.Common.Models;
    using System.Collections.Generic;

    public class Group : BaseModel<int>, IAuditInfo
    {
        public Group()
        {
            //this.Requests = new HashSet<AccountRequest>();
        }

        [MinLength(2)]
        [MaxLength(20)]
        public string Name { get; set; }

        //public virtual ICollection<AccountRequest> Requests { get; set; }
    }
}
