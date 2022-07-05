namespace App.Domain.Core.BaseData.Dtos;

public class FileTypeDto
{
    public int Id { get; set; }
    public int FileTypeExtentionId { get; set; }
    public string Name { get; set; } = null!;
    public DateTime CreationDate { get; set; }
    public bool IsDeleted { get; set; }
}