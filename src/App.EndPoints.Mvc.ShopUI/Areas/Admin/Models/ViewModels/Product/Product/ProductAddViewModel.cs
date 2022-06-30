using App.Domain.Core.Product.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.EndPoints.Mvc.AdminUI.ViewModels
{
    public class ProductAddViewModel
    {
        [Display(Name = "شناسه")]
        public int Id { get; set; }

        [Required(ErrorMessage = "فیلد الزامی میباشد")]
        [Display(Name = "شناسه دسته بندی")]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "فیلد الزامی میباشد")]
        [Display(Name = "شناسه برند")]
        public int BrandId { get; set; }

        [Required(ErrorMessage = "فیلد الزامی میباشد")]
        [Display(Name = "وزن")]
        public decimal Weight { get; set; }
        [Required(ErrorMessage = "فیلد الزامی میباشد")]
        [Display(Name = "اصل بودن")]
        public bool IsOrginal { get; set; }
        [Display(Name = "توضیحات")]
        [Required(AllowEmptyStrings = true)]
        public string Description { get; set; } = null!;

        [Range(0, 10000, ErrorMessage = "تعداد محصول باید بین {1} تا {2} باشد")]
        [Display(Name = "تعداد")]
        [Required(ErrorMessage = "فیلد الزامی میباشد")]
        public int Count { get; set; }

        [Required(ErrorMessage = "فیلد الزامی میباشد")]
        [Display(Name = "شناسه مدل")]
        public int ModelId { get; set; }

        [Required(ErrorMessage = "فیلد الزامی میباشد")]
        [Display(Name = "قیمت")]
        public long Price { get; set; }

        [Required(ErrorMessage = "لطفا یک گزینه را انتخاب کنید")]
        [Display(Name = "نشان دادن قیمت")]
        public bool IsShowPrice { get; set; }

        [Required(ErrorMessage = "لطفا یک گزینه را انتخاب کنید")]
        [Display(Name = "فعال بودن")]
        public bool IsActive { get; set; }

        [Display(Name = "شناسه اپراتور")]
        [Required(ErrorMessage = "فیلد الزامی میباشد")]
        public int OperatorId { get; set; }

        [Display(Name = "نام محصول")]
        [Required(ErrorMessage = "تکمیل فیلد نام محصول الزامی می باشد")]
        [StringLength(40, ErrorMessage = "حداکثر 40 کاراکتر")]
        [Remote(action: "CheckName", controller: "Product", ErrorMessage = "این محصول قبلا ثبت شده است")]
        public string Name { get; set; } = String.Empty;

        [Display(Name = "رنگ های محصول")]
        public List<int> ColorIds { get; set; } = new List<int>();
        //public List<ProductFile> Images { get; set; } = new List<ProductFile>();
        /*public ProductFile Image { get; set; } = new ProductFile();*/
        public string? fileName { get; set; } = null;
        public string? fileExtension { get; set; } = null;
    }
}
