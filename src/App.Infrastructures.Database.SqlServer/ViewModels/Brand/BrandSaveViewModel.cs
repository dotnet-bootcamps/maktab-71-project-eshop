using System.ComponentModel.DataAnnotations;

namespace App.EndPoints.Mvc.AdminUI.Models
{
	public class BrandSaveViewModel
	{

		[Display(Name ="شناسه")]
        public int Id { get; set; }

		[Display(Name ="نام")]
		public string Name { get; set; }

		[Display(Name ="ترتیب نمایش")]
		public int DisplayOrder { get; set; }
	}
}
