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
    [Table("AnnouncementUser")]
    public class AnnouncementUser : BaseEntity<int>, ISoftDelete, ICreateData
    {
        public string AnnouncementId { get; set; }

        public Guid UserId { get; set; }

        public bool HasRead { get; set; } = false;

        public Announcement Announcement { get; set; }
        public bool IsDeleted { get; set; }
        public string CreateBy { get; set; }
        public string? UpadatedBy { get; set; }
    }
}
