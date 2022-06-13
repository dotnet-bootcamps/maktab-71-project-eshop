using App.Domain.Core.ProductAggrigate.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.ModelAggrigates.Entities
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
