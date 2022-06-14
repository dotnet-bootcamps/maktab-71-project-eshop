using System;
using System.Collections.Generic;

namespace App.Domain.Core.BaseData.Entities
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

        public virtual App.Domain.Core.Product.Entities.Product Product { get; set; } = null!;
        public virtual Status Status { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
