using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.EndPoints.Mvc.AdminUI.ViewModels
{
    public class ProductOutputViewModel
    {
        [Display(Name = "شناسه")]
        public int Id { get; set; }
        [Display(Name = "عکس محصول")]
        public string ImageName { set; get; }
        [Display(Name = "شناسه دسته بندی")]
        public string CategoryName { get; set; }
        [Display(Name = "شناسه برند")]
        public string BrandName { get; set; }
        [Display(Name = "وزن")]
        public decimal Weight { get; set; }
        [Display(Name = "اصل بودن")]
        public bool IsOrginal { get; set; }
        [Display(Name = "توضیحات")]
        public string Description { get; set; } = null!;
        [Display(Name = "تعداد")]
        public int Count { get; set; }
        [Display(Name = "شناسه مدل")]
        public string ModelName { get; set; }
        [Display(Name = "قیمت")]
        public long Price { get; set; }
        [Display(Name = "نشان دادن قیمت")]
        public bool IsShowPrice { get; set; }
        [Display(Name = "فعال بودن")]
        public bool IsActive { get; set; }
        [Display(Name = "شناسه اپراتور")]
        public string OperatorName { get; set; }
        [Display(Name = "نام")]
        public string Name { get; set; } = null!;
        [Display(Name = "تاریخ ثبت")]
        public DateTime CreationDate { get; set; }
        [Display(Name = "حذف شده")]
        public bool IsDeleted { get; set; }
        [Display(Name = "رنگ محصول")]
        public List<string> Colors { set; get; }
    }
}
