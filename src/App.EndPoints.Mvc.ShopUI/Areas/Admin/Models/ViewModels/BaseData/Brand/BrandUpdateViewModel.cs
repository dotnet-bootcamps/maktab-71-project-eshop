using System.ComponentModel.DataAnnotations;

namespace App.EndPoints.Mvc.AdminUI.Models.ViewModels.BaseData.Brand
{
    public class BrandUpdateViewModel
    {
        [Display(Name = "شناسه")]
        public int Id { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "تکمیل فیلد نام اجباری می باشد")]
        public string Name { get; set; } = null!;

        [Display(Name = "ترتیب نمایش")]
        [Required(ErrorMessage = "تکمیل فیلد ترتیب نمایش اجباری می باشد")]
        [Range(1, int.MaxValue, ErrorMessage = "مقدار باید بزرگتر از {1} باشد")]
        public int DisplayOrder { get; set; }

        [Display(Name = "حذف شده")]
        public bool IsDeleted { get; set; }
    }
}
