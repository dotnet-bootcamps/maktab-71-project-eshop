using System.ComponentModel.DataAnnotations;

namespace App.EndPoints.Mvc.AdminUI.Models.ViewModels.BaseData
{
    public class BrandInputVeiwModel
    {
        [Display(Name = ("اولویت نمایش"))]
        public int DisplayOrder { get; set; }
        [Display(Name = ("نام برند"))]
        public string Name { get; set; } = null!;
    }
}
