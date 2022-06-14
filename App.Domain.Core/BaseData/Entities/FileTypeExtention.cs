using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.BaseData.Entities
{
    public class FileTypeExtention
    {
        public FileTypeExtention()
        {
            FileTypes = new HashSet<FileType>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreationDate { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<FileType> FileTypes { get; set; }
    }
}
