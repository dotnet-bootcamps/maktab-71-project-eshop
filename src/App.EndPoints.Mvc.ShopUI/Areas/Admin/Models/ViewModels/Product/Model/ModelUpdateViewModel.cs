using System.ComponentModel.DataAnnotations;

namespace App.EndPoints.Mvc.AdminUI.Models.ViewModels.Product.Model
{
    public class ModelUpdateViewModel
    {
        [Display(Name = "شناسه")]
        public int Id { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "تکمیل فیلد نام اجباری می باشد")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "شناسه مدل والد")]
        // TODO
        public int ParentModelId { get; set; }
        [Display(Name = "شناسه برند")]
        // TODO
        public int BrandId { get; set; }
        [Display(Name = "حذف شده")]
        public bool IsDeleted { get; set; }
    }
}
