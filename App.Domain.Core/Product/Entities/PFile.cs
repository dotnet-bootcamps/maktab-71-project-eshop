using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Entities
{
    public class PFile
    {
        #region Properties
        public int Id { get; set; }
        public string FileName { get; set; } = string.Empty;
        public long Size { get; set; }
        #endregion

        #region Navigational Properties 
        public int ProductId { get; set; }
        public virtual Product Product { get; set; } = null!;
        #endregion


    }

}
