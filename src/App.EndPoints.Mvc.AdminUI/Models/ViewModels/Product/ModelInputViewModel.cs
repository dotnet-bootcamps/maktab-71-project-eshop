using System.ComponentModel.DataAnnotations;

namespace App.EndPoints.Mvc.AdminUI.Models.ViewModels.Product
{
    public class ModelInputViewModel
    {
        [Display(Name = (""))]
        public string Name { get; set; } = null!;
        [Display(Name = (""))]
        public int ParentModelId { get; set; }
        [Display(Name = (""))]
        public int BrandId { get; set; }
    }
}
