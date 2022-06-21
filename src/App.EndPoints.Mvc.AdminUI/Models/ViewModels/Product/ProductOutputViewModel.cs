namespace App.EndPoints.Mvc.AdminUI.Models.ViewModels.Product
{
    public class ProductOutputViewModel
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public decimal Weight { get; set; }
        public bool IsOrginal { get; set; }
        public string Description { get; set; } = null!;
        public int Count { get; set; }
        public string Model { get; set; }
        public long Price { get; set; }
        public bool IsShowPrice { get; set; }
        public bool IsActive { get; set; }
        public string Operator { get; set; }
        public int OperatorId { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreationDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
