using System;
using System.Collections.Generic;

namespace App.Domain.Core.Product.Entities
{
    public partial class CategorySpacification
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int TagCategoryId { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual TagCategory TagCategory { get; set; } = null!;
    }
}
