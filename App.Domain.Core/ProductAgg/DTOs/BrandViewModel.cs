using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.ProductAgg.DTOs
{
    public class BrandViewModel:CreateBrand
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        
    }
}
