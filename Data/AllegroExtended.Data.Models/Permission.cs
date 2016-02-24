namespace AllegroExtended.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AllegroExtended.Data.Common.Models;

    public class Permission : BaseModel<int>, IAuditInfo
    {
        [Required]
        public bool IsReadOnly { get; set; }

        public int GroupId { get; set; }

        public virtual Group Group { get; set; }

        public int ClassEventId { get; set; }

        public virtual ClassEvent ClassEvent { get; set; }
    }
}