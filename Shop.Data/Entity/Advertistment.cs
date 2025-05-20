using Shop.Common.Enums;
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
    [Table("Advertistment")]
    public class Advertistment : BaseEntity<int>, ISort, IDate, ISoftDelete, ICreateData
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public string  Url { get; set; }

        public string PositionId { get; set; }


        public int SortOrder { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

        public AdvertistmentPosition AdvertistmentPosition { get; set; }
        public bool IsDeleted { get; set; }
        public string CreateBy { get; set; }
        public string? UpadatedBy { get; set; }
    }
}
