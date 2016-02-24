namespace AllegroExtended.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AllegroExtended.Common;
    using AllegroExtended.Data.Common.Models;

    public class ClassEvent : BaseModel<int>, IAuditInfo
    {
        public ClassEvent()
        {
            this.Permissions = new HashSet<Permission>();
        }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(150)]
        public string Description { get; set; }

        public string Schedule { get; set; }

        public DateTime NextRunOn { get; set; }

        public DateTime LastRunOn { get; set; }

        public virtual ICollection<Permission> Permissions { get; set; }
    }
}
