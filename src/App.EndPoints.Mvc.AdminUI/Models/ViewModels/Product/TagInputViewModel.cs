using System.ComponentModel.DataAnnotations;

namespace App.EndPoints.Mvc.AdminUI.Models.ViewModels.Product
{
    public class TagInputViewModel
    {
        [Display(Name = (""))]
        public string Name { get; set; } = null!;
        [Display(Name = (""))]
        public int TagCategoryId { get; set; }
        [Display(Name = (""))]
        public bool HasValue { get; set; }
    }
}
