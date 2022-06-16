using App.Domain.Core.Product.Entities;
using System;
using System.Collections.Generic;

namespace App.Domain.Core.Product.Entities
{
    public partial class Tag
    {
        public Tag()
        {
            ProductTags = new HashSet<ProductTag>();
        }

        public int Id { get; set; }
        public int TagCategoryId { get; set; }
        public bool HasValue { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreationDate { get; set; }
        public bool IsDeleted { get; set; }

        public virtual TagCategory TagCategory { get; set; } = null!;
        public virtual ICollection<ProductTag> ProductTags { get; set; }
    }
}
