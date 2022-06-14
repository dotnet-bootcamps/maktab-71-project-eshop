using App.Domain.Core.Product_Aggregate.Entities;
using System;
using System.Collections.Generic;

namespace App.Domain.Core.BaseData_Aggregate.Entities
{
    public class Model
    {
        public Model()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public int ParentModelId { get; set; }
        public int BrandId { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreationDate { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
