using System;
using System.Collections.Generic;
using ProductEntities= App.Domain.Core.Product.Entities;

namespace App.Domain.Core.BaseData.Entities
{
    public partial class Model
    {
        public Model()
        {
            Products = new HashSet<ProductEntities.Product>();
        }

        public int Id { get; set; }
        public int ParentModelId { get; set; }
        public int BrandId { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreationDate { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<ProductEntities.Product> Products { get; set; }
    }
}
