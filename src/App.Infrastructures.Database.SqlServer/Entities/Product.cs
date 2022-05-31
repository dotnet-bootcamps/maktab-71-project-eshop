namespace App.Infrastructures.Database.SqlServer.Entities
{
    public partial class Product
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

        #region Values

        public int Id { get; set; }
        [MaxLength(250)]
        public string Name { get; set; } = null!;
        public long Price { get; set; }
        public float? Weight { get; set; }
        public int Stock { get; set; }
        public DateTimeOffset CreationDate { get; set; }
        public string? Description { get; set; }

        public bool IsOrginal { get; set; }
        public bool IsActive { get; set; }
        public bool IsShowPrice { get; set; }
        public bool IsDeleted { get; set; }

        #endregion

        #region Classes

        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; } = null!;

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; } = null!;

        public int ModelId { get; set; }
        public virtual Model Model { get; set; } = null!;

        public int OperatorId { get; set; }
        public virtual Operator Operator { get; set; } = null!;

        #endregion

        #region Collections

        public virtual ICollection<CollectionProduct> CollectionProducts { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<ProductColor> ProductColors { get; set; }
        public virtual ICollection<ProductFile> ProductFiles { get; set; }
        public virtual ICollection<ProductTag> ProductTags { get; set; }
        public virtual ICollection<ProductView> ProductViews { get; set; }

        #endregion
    }
}
