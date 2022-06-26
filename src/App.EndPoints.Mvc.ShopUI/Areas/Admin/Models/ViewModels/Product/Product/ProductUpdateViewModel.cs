using System.ComponentModel.DataAnnotations;

namespace App.EndPoints.Mvc.AdminUI.Models.ViewModels.Product.Product
{
    public class ProductUpdateViewModel
    {
        [Display(Name = "شناسه")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "شناسه دسته بندی")]
        public int CategoryId { get; set; }
        [Required]
        [Display(Name = "شناسه برند")]
        public int BrandId { get; set; }
        [Display(Name = "وزن")]
        public decimal Weight { get; set; }
        [Required]
        [Display(Name = "اصل بودن")]
        public bool IsOrginal { get; set; }
        [Display(Name = "توضیحات")]
        public string Description { get; set; } = null!;

        [Required]
        [Range(0, 10000, ErrorMessage = "تعداد محصول باید بین {1} تا {2} باشد")]
        [Display(Name = "تعداد")]
        public int Count { get; set; }


        [Display(Name = "شناسه مدل")]
        public int ModelId { get; set; }

        [Required]
        [Display(Name = "قیمت")]
        public long Price { get; set; }

        [Required(ErrorMessage = "لطفا یک گزینه را انتخاب کنید")]
        [Display(Name = "نشان دادن قیمت")]
        public bool IsShowPrice { get; set; }

        [Required(ErrorMessage = "لطفا یک گزینه را انتخاب کنید")]
        [Display(Name = "فعال بودن")]
        public bool IsActive { get; set; }

        [Display(Name = "شناسه اپراتور")]
        public int OperatorId { get; set; }

        [Display(Name = "نام محصول")]
        [Required(ErrorMessage = "تکمیل فیلد نام محصول الزامی می باشد")]
        [StringLength(40, ErrorMessage = "حداکثر 40 کاراکتر")]
        public string Name { get; set; } = String.Empty;
        [Display(Name = "حذف شده")]
        public bool IsDeleted { get; set; }

        [Display(Name = "رنگ های محصول")]
        public List<int> ColorIds { get; set; } = new List<int>();
    }
}
