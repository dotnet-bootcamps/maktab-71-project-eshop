namespace App.Infrastructures.Database.SqlServer.Entities
{
    public partial class ProductTag
    {
        #region Values

        public int Id { get; set; }
        [MaxLength(250)]
        public string Name { get; set; } = null!;
        [MaxLength(500)]
        public string? Value { get; set; }
        public DateTimeOffset CreationDate { get; set; }
        public bool IsDeleted { get; set; }

        #endregion

        #region Classes

        public int ProductId { get; set; }
        public virtual Product Product { get; set; } = null!;
        public int TagId { get; set; }
        public virtual Tag Tag { get; set; } = null!; 

        #endregion
    }
}
