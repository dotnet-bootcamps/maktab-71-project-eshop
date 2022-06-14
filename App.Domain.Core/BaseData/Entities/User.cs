using System;
using System.Collections.Generic;

namespace App.Domain.Core.BaseData.Entities
{
    public partial class User
    {
        public User()
        {
            Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreationDate { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
