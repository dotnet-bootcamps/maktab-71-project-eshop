namespace App.Infrastructures.Database.SqlServer.Entities
{
    public partial class FileTypeExtention
    {

        public FileTypeExtention()
        {
            ProductFiles = new HashSet<ProductFile>();
        }
        #region Values

        public int Id { get; set; }
        [MaxLength(250)]
        public string Name { get; set; } = null!;
        public DateTimeOffset CreationDate { get; set; }
        public bool IsDeleted { get; set; } 

        #endregion

        #region Classes

        public int FileTypeId { get; set; }
        public virtual FileType FileType { get; set; } = null!;

        #endregion

        #region Collections

        public virtual ICollection<ProductFile> ProductFiles { get; set; }

        #endregion
    }
}
