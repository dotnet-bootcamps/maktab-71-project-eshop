using System.ComponentModel.DataAnnotations;

namespace App.EndPoints.Mvc.AdminUI.Models.ViewModels.Product
{
    public class CollectionInputViewModel
    {
        [Display(Name = (""))]
        public string Name { get; set; } = null!;
    }
}
