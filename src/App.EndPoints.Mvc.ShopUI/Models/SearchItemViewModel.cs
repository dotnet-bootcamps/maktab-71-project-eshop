using App.Domain.Core.Product.Dtos;
using App.Domain.Core.Product.Dtos.Color;

namespace App.EndPoints.Mvc.ShopUI.Models
{
    public class SearchItemViewModel
    {
        public int ProductId { get; set; }
        public List<string>? ImageName { get; set; }
        public List<ColorDto>? ColoList { get; set; }
        public List<ProductTagDto>? ProductTags { get; set; }


        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductPrice { get; set; }
    }
}