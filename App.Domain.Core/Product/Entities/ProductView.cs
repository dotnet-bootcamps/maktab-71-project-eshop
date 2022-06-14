using System;
using System.Collections.Generic;

namespace App.Domain.Core.Product.Entities
{
    public partial class ProductView
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public DateTime ViewTime { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreationDate { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Product Product { get; set; } = null!;
    }
}
