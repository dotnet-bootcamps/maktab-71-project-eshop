using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Dtos
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public int DisplayOrder { get; set; }
        public string Name { get; set; } = null!;
        public int ParentCategoryId { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
