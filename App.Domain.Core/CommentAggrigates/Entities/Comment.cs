using App.Domain.Core.ProductAggrigate.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.CommentAggrigates.Entities
{
    public class Comment
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

            public virtual Product Product { get; set; } = null!;
            public virtual BaseData.Entities.Status Status { get; set; } = null!;
            public virtual UserAggrigates.Entities.User User { get; set; } = null!;
        }
}
