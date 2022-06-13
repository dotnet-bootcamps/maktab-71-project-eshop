using System.ComponentModel.DataAnnotations;

namespace App.EndPoints.Mvc.AdminUI.Models
{
    public class CategoryListVM
    {
        [Display(Name = "شناسه")]
        public int Id { get; set; }

        [Display(Name = "نام")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "فعال بودن")]
        public bool IsActive { get; set; }

        [Display(Name = "ترتیب نمایش")]
        public int DisplayOrder { get; set; }

        [Display(Name = " شناسه دسته بندی")]
        public int ParentCategoryId { get; set; }

        [Display(Name = "تاریخ ثبت")]
        public DateTime CreationDate { get; set; }

    }
}
