using System.ComponentModel.DataAnnotations;

namespace App.EndPoints.Mvc.AdminUI.Models.ViewModels.Product
{
    public class TagOutputViewModel
    {
        [Display(Name =(""))]
        public int Id { get; set; }
        [Display(Name = (""))]
        public int TagCategoryId { get; set; }
        [Display(Name = (""))]
        public bool HasValue { get; set; }
        [Display(Name = (""))]
        public string Name { get; set; } = null!;
        [Display(Name = (""))]
        public DateTime CreationDate { get; set; }
        [Display(Name = (""))]
        public bool IsDeleted { get; set; }
    }
}
