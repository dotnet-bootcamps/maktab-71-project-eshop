using System;
using System.Collections.Generic;
using ProductEntities =  App.Domain.Core.Product.Entities;

namespace App.Domain.Core.Operator.Entities
{
    public partial class Operator
    {
        public Operator()
        {
            Products = new HashSet<ProductEntities.Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreationDate { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<ProductEntities.Product> Products { get; set; }
    }
}
