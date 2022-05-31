namespace App.Infrastructures.Database.SqlServer.Entities
{
    public partial class User
    {
        public User()
        {
            Comments = new HashSet<Comment>();
        }

        #region Values

        public int Id { get; set; }
        [MaxLength(250)]
        public string Name { get; set; } = null!;
        public DateTimeOffset LastChangeTime { get; set; }
        public DateTimeOffset CreationDate { get; set; }
        public bool IsDeleted { get; set; }

        #endregion

        #region Collections

        public virtual ICollection<Comment> Comments { get; set; }

        #endregion

    }
}
