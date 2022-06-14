using System;
using System.Collections.Generic;

namespace App.Domain.Core.Product_Aggregate.Entities
{
    public class CollectionProduct
    {
        public int Id { get; set; }
        public int CollectionId { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreationDate { get; set; }
        public int IsDeleted { get; set; }

        public virtual Collection Collection { get; set; } = null!;
        public virtual Product CollectionNavigation { get; set; } = null!;
    }
}
