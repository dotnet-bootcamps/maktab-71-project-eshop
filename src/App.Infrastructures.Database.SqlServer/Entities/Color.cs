namespace App.Infrastructures.Database.SqlServer.Entities
{
    public partial class Color
    {
        public Color()
        {
            ProductColors = new HashSet<ProductColor>();
        }

        #region Values

        public int Id { get; set; }
        [MaxLength(250)]
        public string Name { get; set; } = null!;
        [MaxLength(50)]
        public string Code { get; set; } = null!;
        public DateTime CreationDate { get; set; }
        public bool IsDeleted { get; set; }

        #endregion

        #region Collections

        public virtual ICollection<ProductColor> ProductColors { get; set; } 

        #endregion
    }
}
