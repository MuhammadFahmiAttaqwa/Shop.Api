﻿using Shop.Data.Base;
using Shop.Data.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Entity
{
    [Table("ProductQuantity")]
    public class ProductQuantity : BaseEntity<int>, ISoftDelete, ICreateData
    {
        public int ProductId { get; set; }

        public int SizeId { get; set; }

        public int ColorId { get; set; }

        public int Quantity { get; set; }

        public Product Product { get; set; }

        public Color Color { get; set; }

        public Size Size { get; set; }
        public bool IsDeleted { get; set; }
        public string CreateBy { get; set; }
        public string? UpadatedBy { get; set; }
    }
}
