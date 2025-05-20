using Shop.Data.Base;
using Shop.Data.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Entity
{
    [Table("AdvertistmentPositions")]
    public class AdvertistmentPosition : BaseEntity<string>, ISoftDelete, IDate, ICreateData
    {
        public string PageId { get; set; }

        public string Name { get; set; }

        public AdvertistmentPage AdvertistmentPage { get; set; }

        public List<Advertistment> Advertistment { get; set; } = new List<Advertistment>();
        public bool IsDeleted { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string CreateBy { get; set; }
        public string? UpadatedBy { get; set; }
    }
}
