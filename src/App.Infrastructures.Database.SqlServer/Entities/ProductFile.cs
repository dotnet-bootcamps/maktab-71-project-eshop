namespace App.Infrastructures.Database.SqlServer.Entities
{
    public partial class ProductFile
    {
        #region Values

        public int Id { get; set; }
        [MaxLength(250)]
        public string Name { get; set; } = null!;
        public DateTimeOffset CreationDate { get; set; }
        public bool IsDeleted { get; set; }

        #endregion

        #region Classes

        public int FileTypeExtentionId { get; set; }
        public virtual FileTypeExtention FileTypeExtention { get; set; } = null!;
        public int ProductId { get; set; }
        public virtual Product Product { get; set; } = null!;

        #endregion
    }
}
