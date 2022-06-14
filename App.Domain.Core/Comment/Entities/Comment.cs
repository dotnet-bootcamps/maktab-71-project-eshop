using System;
using System.Collections.Generic;
using App.Domain.Core.Product.Entities;
using productEntities = App.Domain.Core.Product.Entities;
using userEntities = App.Domain.Core.User.Entities;

namespace App.Domain.Core.Comment.Entities
{
    public partial class Comment
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string CommentText { get; set; } = null!;
        public int StatusId { get; set; }
        public int UserId { get; set; }
        public int ParentCommentId { get; set; }
        public DateTime LastEditTime { get; set; }
        public int EditorOperationId { get; set; }
        public int Rate { get; set; }
        public int LikeCount { get; set; }
        public int DisLikeCount { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreationDate { get; set; }
        public bool IsDeleted { get; set; }

        public virtual productEntities.Product Product { get; set; } = null!;
        public virtual Status Status { get; set; } = null!;
        public virtual userEntities.User User { get; set; } = null!;
    }
}
