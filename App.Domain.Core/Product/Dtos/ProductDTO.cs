using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Dtos
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public decimal Weight { get; set; }
        public bool IsOrginal { get; set; }
        public string Description { get; set; } = null!;
        public int Count { get; set; }
        public long Price { get; set; }
        public bool IsShowPrice { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreationDate { get; set; }
        public bool IsDeleted { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public int ModelId { get; set; }
        public int OperatorId { get; set; }

        public string CategoryName { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }

    }
}
