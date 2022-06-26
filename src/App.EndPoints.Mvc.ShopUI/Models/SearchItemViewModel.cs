namespace App.EndPoints.Mvc.ShopUI.Models
{
    public class SearchItemViewModel
    {
        public int ProductId { get; set; }
        public string ImageName { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductPrice { get; set; }
    }
}