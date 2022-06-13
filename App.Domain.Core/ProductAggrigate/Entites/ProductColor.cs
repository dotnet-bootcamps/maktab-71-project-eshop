using App.Domain.Core.BaseData;
using App.Domain.Core.BaseData.Entities;
using System;
using System.Collections.Generic;

namespace App.Domain.Core.ProductAggrigate.Entites
{
    public class ProductColor
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ColorId { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreationDate { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Color Color { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
