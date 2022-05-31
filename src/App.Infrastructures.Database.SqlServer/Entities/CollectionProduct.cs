namespace App.Infrastructures.Database.SqlServer.Entities
{
    public partial class CollectionProduct
    {
        #region Values

        public int Id { get; set; }
        [MaxLength(250)]
        public string Name { get; set; } = null!;
        public DateTimeOffset CreationDate { get; set; }
        public bool IsDeleted { get; set; } 

        #endregion

        #region Classes

        public int ProductId { get; set; }
        public virtual Product Product { get; set; } = null!;

        public int CollectionId { get; set; }
        public virtual Collection Collection { get; set; } = null!; 

        #endregion
    }
}
