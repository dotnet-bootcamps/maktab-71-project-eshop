using App.Domain.Core.BaseData.Entities;
using System;
using System.Collections.Generic;

namespace App.Domain.Core.Product.Entities
{
    public partial class ProductFile
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int FileTypeId { get; set; }

        public virtual FileType FileType { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
