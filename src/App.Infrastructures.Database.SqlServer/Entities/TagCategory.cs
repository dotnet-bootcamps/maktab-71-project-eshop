namespace App.Infrastructures.Database.SqlServer.Entities
{
    public partial class TagCategory
    {
        public TagCategory()
        {
            Tags = new HashSet<Tag>();
        }

        #region Values

        public int Id { get; set; }
        [MaxLength(250)]
        public string Name { get; set; } = null!;
        public DateTimeOffset CreationDate { get; set; }
        public bool IsDeleted { get; set; }

        #endregion

        #region Collections

        public virtual ICollection<Tag> Tags { get; set; }

        #endregion
    }
}
