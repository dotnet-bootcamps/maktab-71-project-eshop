namespace App.Infrastructures.Database.SqlServer.Entities
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        #region Values

        public int Id { get; set; }
        [MaxLength(250)]
        public string Name { get; set; } = null!;
        public int DisplayOrder { get; set; }
        public DateTimeOffset CreationDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        #endregion

        #region Classes

        public int? ParentCagetoryId { get; set; }
        public virtual Category? ParentCagetory { get; set; } 

        #endregion

        #region Collections

        public virtual ICollection<Category> ChildCategories { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        #endregion

    }
}
