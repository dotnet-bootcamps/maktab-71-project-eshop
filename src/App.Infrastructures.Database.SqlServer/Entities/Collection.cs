namespace App.Infrastructures.Database.SqlServer.Entities
{
    public partial class Collection
    {
        public Collection()
        {
            CollectionProducts = new HashSet<CollectionProduct>();
        }

        #region Values

        public int Id { get; set; }
        [MaxLength(250)]
        public string Name { get; set; } = null!;
        public DateTimeOffset CreationDate { get; set; }
        public bool IsDeleted { get; set; }

        #endregion

        #region Collections

        public virtual ICollection<CollectionProduct> CollectionProducts { get; set; }

        #endregion
    }
}
