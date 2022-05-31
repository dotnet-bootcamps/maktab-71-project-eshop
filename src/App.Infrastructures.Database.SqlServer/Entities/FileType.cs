namespace App.Infrastructures.Database.SqlServer.Entities
{
    public partial class FileType
    {
        public FileType()
        {

            FileTypeExtentions = new HashSet<FileTypeExtention>();
        }

        #region Valeus

        public int Id { get; set; }
        [MaxLength(250)]
        public string Name { get; set; } = null!;
        public DateTimeOffset CreationDate { get; set; }
        public bool IsDeleted { get; set; }

        #endregion


        #region Collections

        public virtual ICollection<FileTypeExtention> FileTypeExtentions { get; set; }

        #endregion
    }
}
