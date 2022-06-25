using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace App.EndPoints.Mvc.AdminUI.Models.ViewModels.Product.Category
{
    public class CategoryUpdateViewModel
    {
        [Display(Name = "شناسه")]
        public int Id { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "تکمیل فیلد نام اجباری می باشد")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "فعال بودن")]
        [Required(ErrorMessage = "لطفا یک گزینه را انتخاب کنید")]
        public bool IsActive { get; set; }

        [Display(Name = "ترتیب نمایش")]
        [Required(ErrorMessage = "تکمیل فیلد ترتیب نمایش اجباری می باشد")]
        [Range(1, int.MaxValue, ErrorMessage = "مقدار باید بزرگتر از {1} باشد")]
        public int DisplayOrder { get; set; }

        [Display(Name = " شناسه دسته بندی")]
        [Required(ErrorMessage = "تکمیل فیلد شناسه دسته بندی اجباری می باشد")]
        // TODO
        public int ParentCategoryId { get; set; }

        [Display(Name = "حذف شده")]
        public bool IsDeleted { get; set; }
    }
}
