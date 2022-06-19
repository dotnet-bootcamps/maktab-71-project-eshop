using System;
using System.Collections.Generic;

namespace App.Domain.Core.BaseData.Entities
{
    public partial class Brand
    {
        public Brand()
        {
            Products = new HashSet<App.Domain.Core.Product.Entities.Product>();
        }

        public int Id { get; set; }
        public int DisplayOrder { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreationDate { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<App.Domain.Core.Product.Entities.Product> Products { get; set; }
    }
}
