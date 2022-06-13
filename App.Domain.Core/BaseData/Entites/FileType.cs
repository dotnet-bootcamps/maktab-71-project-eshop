using App.Domain.Core.ProductAggrigate.Entites;
using System;
using System.Collections.Generic;

namespace App.Domain.Core.BaseData.Entities
{
    public class FileType
    {
        public FileType()
        {
            ProductFiles = new HashSet<ProductFile>();
        }

        public int Id { get; set; }
        public int FileTypeExtentionId { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreationDate { get; set; }
        public bool IsDeleted { get; set; }

        public virtual FileTypeExtention FileTypeExtention { get; set; } = null!;
        public virtual ICollection<ProductFile> ProductFiles { get; set; }
    }
}
