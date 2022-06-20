using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Dtos
{
    public class CategorySaveDto
    {
        public bool IsActive { get; set; }
        public int DisplayOrder { get; set; }
        public int ParentCagetoryId { get; set; }
        public string Name { get; set; } = String.Empty;
        public bool IsDeleted { get; set; }
    }
}
