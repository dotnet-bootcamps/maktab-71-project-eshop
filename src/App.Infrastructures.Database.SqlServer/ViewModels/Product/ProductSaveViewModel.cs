using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Database.SqlServer.ViewModels.Product
{
    public class ProductSaveViewModel
    {
        [Display(Name = "شناسه")]
        public int Id { get; set; }
        [Display(Name = "شناسه دسته بندی")]
        public int CategoryId { get; set; }
        [Display(Name = "شناسه برند")]
        public int BrandId { get; set; }
        [Display(Name = "وزن")]
        public decimal Weight { get; set; }
        [Display(Name = "اصل بودن")]
        public bool IsOrginal { get; set; }
        [Display(Name = "توضیحات")]
        public string Description { get; set; } = null!;
        [Display(Name = "تعداد")]
        public int Count { get; set; }
        [Display(Name = "شناسه مدل")]
        public int ModelId { get; set; }
        [Display(Name = "قیمت")]
        public long Price { get; set; }
        [Display(Name = "نشان دادن قیمت")]
        public bool IsShowPrice { get; set; }
        [Display(Name = "فعال بودن")]
        public bool IsActive { get; set; }
        [Display(Name = "شناسه اپراتور")]
        public int OperatorId { get; set; }
        [Display(Name = "نام")]
        public string Name { get; set; } = String.Empty;
        [Display(Name = "حذف شده")]
        public bool IsDeleted { get; set; }
    }
}
