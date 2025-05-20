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
    [Table("AdvertistmentPages")]
    public class AdvertistmentPage: BaseEntity<string>, ISoftDelete, ICreateData, IDate
    {
        public string Name { get; set; }

        public List<AdvertistmentPosition> AdvertistmentPosition { get; set; } = new List<AdvertistmentPosition>();

        public bool IsDeleted { get; set; }
        public string CreateBy { get; set; }
        public string? UpadatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
