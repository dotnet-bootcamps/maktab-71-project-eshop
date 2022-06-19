using System;
using System.Collections.Generic;

namespace App.Domain.Core.BaseData.Entities
{
    public partial class FileTypeExtention
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
