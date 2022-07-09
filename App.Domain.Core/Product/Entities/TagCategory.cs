using System;
using System.Collections.Generic;

namespace App.Domain.Core.Product.Entities
{
    public partial class TagCategory
    {
        public TagCategory()
        {
            Tags = new HashSet<Tag>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public bool HasValue { get; set; }
        public bool IsMult { set; get; }

        public DateTime CreationDate { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<CategorySpacification> CategorySpacifications { get; set; }
    }
}
