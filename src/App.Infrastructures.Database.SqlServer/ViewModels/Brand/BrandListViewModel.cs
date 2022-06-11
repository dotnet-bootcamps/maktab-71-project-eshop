﻿using System.ComponentModel.DataAnnotations;

namespace App.EndPoints.Mvc.AdminUI.Models.Brand
{
    public class BrandListViewModel
    {
		[Display(Name = "شناسه")]
		public int Id { get; set; }

		[Display(Name = "نام")]
		public string Name { get; set; } = string.Empty;

		[Display(Name = "تاریخ ایجاد")]
		public DateTime CreationDate { get; set; }

		[Display(Name = "ترتیب نمایش")]
		public int DisplayOrder { get; set; }
		
	}
}
