namespace App.EndPoints.Mvc.ShopUI.Models
{
    public class CartItemViewModel
    {
        public int ProductId { get; set; }
        public string ImageName { get; set; }
        public string ProductName { get; set; }
        public string ProductPrice { get; set; }
        public int Count { get; set; }
    }
}