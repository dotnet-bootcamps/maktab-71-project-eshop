using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.EndPoints.Mvc.AdminUI.ViewModels
{
    public class ModelInputViewModel
    {
		[Display(Name = "شناسه")]
		public int Id { get; set; }

		[Display(Name = "نام")]
		public string Name { get; set; } = string.Empty;

		[Display(Name = "شناسه مدل والد")]
		public int ParentModelId { get; set; }
		[Display(Name = "شناسه برند")]
		public int BrandId { get; set; }
		[Display(Name = "حذف شده")]
		public bool IsDeleted { get; set; }
	}
}
