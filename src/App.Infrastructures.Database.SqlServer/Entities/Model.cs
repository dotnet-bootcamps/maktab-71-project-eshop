namespace App.Infrastructures.Database.SqlServer.Entities
{
    public partial class Model
    {
        public Model()
        {
            Products = new HashSet<Product>();
            ChildModels = new HashSet<Model>();
        }

        #region Values

        public int Id { get; set; }
        [MaxLength(250)]
        public string Name { get; set; } = null!;
        public DateTimeOffset CreationDate { get; set; }
        public bool IsDeleted { get; set; } 

        #endregion

        #region Classes

        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }
        public int? ParentModelId { get; set; }
        public virtual Model? ParentModel { get; set; }

        #endregion

        #region Collections

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Model> ChildModels{ get; set; }

        #endregion
    }
}
