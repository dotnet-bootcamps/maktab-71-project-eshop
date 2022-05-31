namespace App.Infrastructures.Database.SqlServer.Entities
{
    public partial class Brand
    {
        public Brand()
        {
            Products = new HashSet<Product>();
        }

        #region Values

        public int Id { get; set; }
        [MaxLength(250)]
        public string Name { get; set; } = null!;
        public int DisplayOrder { get; set; }
        public DateTimeOffset CreationDate { get; set; }
        public bool IsDeleted { get; set; }

        #endregion

        #region Collections

        public virtual ICollection<Product> Products { get; set; }

        #endregion

    }
}
