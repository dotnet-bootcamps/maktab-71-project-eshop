﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace App.EndPoints.Mvc.AdminUI.Models.ViewModels.Product
{
    public class BrandAddViewModel
    {
        [Display(Name = "شناسه")]
        public int Id { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "تکمیل فیلد نام اجباری می باشد")]
        public string Name { get; set; } = null!;


        //[Display(Name = "تکرار نام")]
        //[Required(ErrorMessage = "تکمیل فیلد تکرار نام اجباری می باشد")]
        //[Compare(nameof(Name),ErrorMessage ="فیلد نام و تکرار نام باید یکسان باشند")]
        //public string ConfirmName { get; set; } = null!;


        //[Display(Name = "سازنده")]
        //[Required(ErrorMessage = "تکمیل فیلد تکرار سازنده می باشد")]
        //[Remote("CheckName","Brand",ErrorMessage ="این سازنده این برند را ندارد")]
        //public string Manufacturer { get; set; } = null!;

        [Display(Name = "ترتیب نمایش")]
        [Required(ErrorMessage = "تکمیل فیلد ترتیب نمایش اجباری می باشد")]
        [Range(1, int.MaxValue, ErrorMessage = "مقدار باید بزرگتر از {1} باشد")]
        public int DisplayOrder { get; set; }
    }
}
