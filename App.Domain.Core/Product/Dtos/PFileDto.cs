using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Dtos
{
    public class PFileDto
    {
        public int Id { get; set; }
        public string FileName { get; set; } = string.Empty;
        public long Size { get; set; }
        public int ProductId { get; set; }
    }
}
