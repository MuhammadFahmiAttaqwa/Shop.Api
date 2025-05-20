using Shop.Common.Enums;
using Shop.Data.Base;
using Shop.Data.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Entity
{
    [Table("Announcement")]
    public class Announcement : BaseEntity<string>, IDate, ISoftDelete, ICreateData
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public Guid UserId { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

        public AppUser AppUser { get; set; }

        public List<AnnouncementUser> AnnouncementUser { get; set; } = new List<AnnouncementUser>();
        public bool IsDeleted { get; set; }
        public string CreateBy { get; set; }
        public string? UpadatedBy { get; set; }
    }
}
