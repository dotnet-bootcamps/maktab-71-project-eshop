namespace App.Infrastructures.Database.SqlServer.Entities
{
    public partial class Operator
    {
        public Operator()
        {
            Products = new HashSet<Product>();
            EditedComments=new HashSet<Comment>();
        }

        public int Id { get; set; }
        [MaxLength(250)]
        public string Name { get; set; } = null!;
        public DateTimeOffset CreationDate { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Comment> EditedComments { get; set; }
    }
}
