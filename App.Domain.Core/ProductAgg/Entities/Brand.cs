﻿using System;
using System.Collections.Generic;

namespace App.Domain.Core.ProductAgg.Entities
{
    public partial class Brand
    {
        public Brand()
        {
            Products = new HashSet<Product>();
        }

        public Brand( string name , int displayOrder)
        {
            Name = name;
            CreationDate = DateTime.Now;
            IsDeleted = false;
            DisplayOrder = displayOrder;
        }

        public int Id { get; set; }
        public int DisplayOrder { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreationDate { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
