﻿using App.Domain.Core.BaseDataAgg.Entities;
using System;
using System.Collections.Generic;

namespace App.Domain.Core.ProductAgg.Entities
{
    public partial class ProductColor
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
