using System.ComponentModel.DataAnnotations;

namespace master_backend.Models.ModelImplementations.BlockModels;

public class BlockKeyword
{
    [Key]
    public long blockKeywordId { get; set; }
    
    [Required, MaxLength(100)]
    public string keyword { get; set; } = string.Empty;
}