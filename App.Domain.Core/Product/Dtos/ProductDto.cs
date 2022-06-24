using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public int ModelId { get; set; }
        public decimal Weight { get; set; }
        public string Description { get; set; } = null!;
        public int Count { get; set; }     
        public long Price { get; set; }         
      
        public DateTime CreationDate { get; set; }
        public string CreationDate_Miladi { get; set; }
    }
}
