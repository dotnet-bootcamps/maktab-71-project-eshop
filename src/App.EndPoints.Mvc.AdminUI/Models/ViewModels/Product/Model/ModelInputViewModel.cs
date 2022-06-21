using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Database.SqlServer.ViewModels.Model
{
    public class ModelInputViewModel
    {
		[Display(Name = "شناسه")]
		public int Id { get; set; }

		[Display(Name = "نام")]
		public string Name { get; set; } = string.Empty;

		[Display(Name = "ترتیب نمایش")]
		public int DisplayOrder { get; set; }
		[Display(Name = "شناسه مدل والد")]
		public int ParentModelId { get; set; }
		[Display(Name = "شناسه برند")]
		public int BrandId { get; set; }
		[Display(Name = "حذف شده")]
		public bool IsDeleted { get; set; }
	}
}
