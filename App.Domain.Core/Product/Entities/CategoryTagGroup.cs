using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Entities
{
    public class CategoryTagGroup
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int TagCategoryId { get; set; }
        public Category Category { get; set; } = null!;
        public TagCategory TagCategory { get; set; } = null!;
    }
}
