using App.Domain.Core.ProductAgg.Entities;
using System;
using System.Collections.Generic;
namespace App.Domain.Core.UserAgg.Entities
{
    public partial class Operator
    {
        public Operator()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreationDate { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
