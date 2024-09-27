using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.EndPoints.Mvc.AdminUI.ViewModels
{
    public class ModelAddViewModel
    {
        [Display(Name = "شناسه")]
        public int Id { get; set; }

        [Display(Name = "نام مدل")]
        [Required(ErrorMessage = "تکمیل فیلد نام اجباری می باشد")]
        [Remote(action: "CheckName", controller: "Model", ErrorMessage = "این مدل قبلا ثبت شده است")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "شناسه والد مدل")]
        [Range(0, int.MaxValue, ErrorMessage = "شناسه مدل والد باید بین {1} و {2} باشد")]
        [Required]
        public int ParentModelId { get; set; }
        [Display(Name = "شناسه برند")]
        [Required(ErrorMessage = "شناسه برند الزامی میباشد")]
        public int BrandId { get; set; }
    }
}
