using App.Domain.Core.BaseData.Entities;
using OperatorEntities = App.Domain.Core.Operator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Entities
{
    public class Product
    {
        public Product()
        {
            CollectionProducts = new HashSet<CollectionProduct>();
            Comments = new HashSet<Comment>();
            ProductColors = new HashSet<ProductColor>();
            ProductFiles = new HashSet<ProductFile>();
            ProductTags = new HashSet<ProductTag>();
            ProductViews = new HashSet<ProductView>();
        }

        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public decimal Weight { get; set; }
        public bool IsOrginal { get; set; }
        public string Description { get; set; } = null!;
        public int Count { get; set; }
        public int ModelId { get; set; }
        public long Price { get; set; }
        public bool IsShowPrice { get; set; }
        public bool IsActive { get; set; }
        public int OperatorId { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreationDate { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Brand Brand { get; set; } = null!;
        public virtual Category Category { get; set; } = null!;
        public virtual Model Model { get; set; } = null!;
        public virtual OperatorEntities.Operator Operator { get; set; } = null!;

        public virtual ICollection<CollectionProduct> CollectionProducts { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<ProductColor> ProductColors { get; set; }
        public virtual ICollection<ProductFile> ProductFiles { get; set; }
        public virtual ICollection<ProductTag> ProductTags { get; set; }
        public virtual ICollection<ProductView> ProductViews { get; set; }
    }
}
