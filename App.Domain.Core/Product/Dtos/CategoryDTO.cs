using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Dtos
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public int DisplayOrder { get; set; }
        public int ParentCagetoryId { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreationDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
