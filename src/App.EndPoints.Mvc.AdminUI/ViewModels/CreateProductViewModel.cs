using System.ComponentModel.DataAnnotations;

namespace App.EndPoints.Mvc.AdminUI.ViewModels
{
    public partial class CreateProductViewModel
    {


        [Display(Name = "نام محصول")]
        public string Name { get; set; } = null!;

        [Display(Name = "دسته بندی")]
        public int CategoryId { get; set; }

        [Display(Name = "برند")]
        public int BrandId { get; set; }

        [Display(Name = "مدل")]
        public int ModelId { get; set; }

        public decimal Weight { get; set; }
        public bool IsOrginal { get; set; }
        public string Description { get; set; } = null!;
        public int Count { get; set; }
        public long Price { get; set; }
        public bool IsShowPrice { get; set; }
        public bool IsActive { get; set; }
    }
}
