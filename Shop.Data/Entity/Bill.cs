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
    [Table("Bill")]
    public class Bill : BaseEntity<int>, IDate, ISoftDelete, ICreateData
    {
        public string CustomerName { get; set; }

        public string CustomerAddress { get; set; }

        public string CustomerMobile { get; set; }

        public string CustomerMessage { get; set; }

        public Payment Payment { get; set; }

        public BillStatus BillStatus { get; set; }

        public Guid UserId { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? DateUpdated { get; set; }

        public AppUser AppUser { get; set; }

        public List<BillDetail> BillDetail { get; set; } = new List<BillDetail>();
        public bool IsDeleted { get; set; }
        public string CreateBy { get; set; }
        public string? UpadatedBy { get; set; }
    }
}
