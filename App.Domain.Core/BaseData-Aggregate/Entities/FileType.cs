using App.Domain.Core.Product_Aggregate.Entities;
using System;
using System.Collections.Generic;

namespace App.Domain.Core.BaseData_Aggregate.Entities
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
