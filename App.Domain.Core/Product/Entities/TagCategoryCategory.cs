using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Entities
{
    public class TagCategoryCategory
    {
        public int Id { get; set; }
        
        public int TagCategoryId { get; set; }
        public virtual TagCategory TagCategory { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
