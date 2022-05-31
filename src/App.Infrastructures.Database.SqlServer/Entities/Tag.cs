namespace App.Infrastructures.Database.SqlServer.Entities
{
    public partial class Tag
    {
        public Tag()
        {
            ProductTags = new HashSet<ProductTag>();
        }

        #region Values

        public int Id { get; set; }
        [MaxLength(250)]
        public string Name { get; set; } = null!;
        public DateTimeOffset CreationDate { get; set; }
        public bool HasValue { get; set; }
        public bool IsDeleted { get; set; }

        #endregion

        #region Classes

        public int TagCategoryId { get; set; }
        public virtual TagCategory TagCategory { get; set; } = null!;

        #endregion

        #region Collections

        public virtual ICollection<ProductTag> ProductTags { get; set; }

        #endregion
    }
}
