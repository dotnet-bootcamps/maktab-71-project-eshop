using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ef_configs.Models.Entities;

public class Category
{
    public byte CategoryId { get; set; }

    [StringLength(150)]
    [Column("CategoryTitle")]
    public string Name { get; set; }

    [NotMapped]
    public string Description { get; set; }

}