using App.Domain.Core.BaseData_Aggregate.Entities;
using System;
using System.Collections.Generic;

namespace App.Domain.Core.Product_Aggregate.Entities
{
    public class ProductFile
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int FileTypeId { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreationDate { get; set; }
        public bool IsDeleted { get; set; }

        public virtual FileType FileType { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
