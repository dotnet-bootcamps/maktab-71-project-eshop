using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.BaseData.Dtos
{
    public class FileTypeExtentionDto
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public DateTime CreationDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
