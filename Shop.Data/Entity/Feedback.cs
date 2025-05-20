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
    [Table("FeedBack")]
    public class Feedback : BaseEntity<int>, IDate, ISoftDelete, ICreateData
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Message { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public bool IsDeleted { get; set; }
        public string CreateBy { get; set; }
        public string? UpadatedBy { get; set; }
    }
}
