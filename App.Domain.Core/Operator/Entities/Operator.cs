using System;
using System.Collections.Generic;

namespace App.Domain.Core.Operator.Entities
{
    public partial class Operator
    {
        public Operator()
        {
            Products = new HashSet<App.Domain.Core.Product.Entities.Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreationDate { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<App.Domain.Core.Product.Entities.Product> Products { get; set; }
    }
}
