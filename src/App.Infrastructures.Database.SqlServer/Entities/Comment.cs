namespace App.Infrastructures.Database.SqlServer.Entities
{
    public partial class Comment
    {
        public Comment()
        {
            ChildComments=new HashSet<Comment>();
        }


        #region Values

        public int Id { get; set; }
        [MaxLength(250)]
        public string Title { get; set; } = null!;
        [MaxLength(3000)]
        public string CommentText { get; set; } = null!;
        public int Rate { get; set; }
        public int LikeCount { get; set; }
        public int DisLikeCount { get; set; }
        public DateTimeOffset LastEditTime { get; set; }
        public DateTimeOffset CreationDate { get; set; }
        public bool IsDeleted { get; set; }

        #endregion

        #region Classes

        public int? EditorOperatorId { get; set; }
        public virtual Operator EditorOperator { get; set; } = null!;

        public int? ParentCommentId { get; set; }
        public virtual Comment? ParentComment { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; } = null!;

        public int StatusId { get; set; }
        public virtual Status Status { get; set; } = null!;

        public int UserId { get; set; }
        public virtual User User { get; set; } = null!;

        #endregion

        #region Collections

        public virtual ICollection<Comment> ChildComments { get; set; }

        #endregion
    }
}
