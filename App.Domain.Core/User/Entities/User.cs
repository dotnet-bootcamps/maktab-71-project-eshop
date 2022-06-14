using System;
using System.Collections.Generic;
using App.Domain.Core.Comment.Entities;
using CommentEntities = App.Domain.Core.Comment.Entities;

namespace App.Domain.Core.User.Entities
{
    public partial class User
    {
        public User()
        {
            Comments = new HashSet<CommentEntities.Comment>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreationDate { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<CommentEntities.Comment> Comments { get; set; }
    }
}
