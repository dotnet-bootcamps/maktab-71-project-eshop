using System;
using System.Collections.Generic;

namespace App.Infrastructures.Database.SqlServer.Entities
{
    public partial class Brand
    {
        public Brand()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public int DisplayOrder { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreationDate { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
