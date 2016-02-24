namespace AllegroExtended.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using AllegroExtended.Common;
    using AllegroExtended.Data.Common.Models;

    public class Message : BaseModel<int>, IAuditInfo
    {
        [Required]
        [MaxLength(100)]
        public string Subject { get; set; }

        [Required]
        [MaxLength(500)]
        public string Content { get; set; }
    }
}
