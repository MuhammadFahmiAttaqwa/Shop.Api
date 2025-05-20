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
    [Table("Function")]
    public class Function : BaseEntity<string>, ISort, ISoftDelete, ICreateData, IDate
    {
        public string Name { get; set; }

        public string URL { get; set; }

        public string IconCss { get; set; }

        public string? ParentId { get; set; }

        public int SortOrder { get; set; }

        public bool IsDeleted { get; set; }

        public string CreateBy { get; set; }

        public string? UpadatedBy { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? DateUpdated { get; set; }
    }
}
