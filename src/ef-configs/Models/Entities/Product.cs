using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ef_configs.Models.Entities
{
    [Table("Kalaha", Schema = "Shop")]
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(250)]
        public string Title { get; set; }

        public byte CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
