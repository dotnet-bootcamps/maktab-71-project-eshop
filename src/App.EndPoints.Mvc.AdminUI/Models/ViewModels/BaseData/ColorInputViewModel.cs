using System.ComponentModel.DataAnnotations;

namespace App.EndPoints.Mvc.AdminUI.Models.ViewModels.BaseData
{
    public class ColorInputViewModel
    {
        [Display(Name = ("نام رنگ"))]
        public string Name { get; set; } = null!;
        [Display(Name = ("کد رنگ"))]
        public string Code { get; set; } = null!;
    }
}
