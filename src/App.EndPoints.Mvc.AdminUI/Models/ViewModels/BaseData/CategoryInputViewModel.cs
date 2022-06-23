using System.ComponentModel.DataAnnotations;

namespace App.EndPoints.Mvc.AdminUI.Models.ViewModels.BaseData
{
    public class CategoryInputViewModel
    {
        [Display(Name = ("نام دسته بندی"))]
        public string Name { get; set; } = null!;
        [Display(Name = ("اولویت نمایش"))]
        public int DisplayOrder { get; set; }
        [Display(Name = ("دسته بندی بالاتر"))]
        public int ParentCagetoryId { get; set; }
    }
}
