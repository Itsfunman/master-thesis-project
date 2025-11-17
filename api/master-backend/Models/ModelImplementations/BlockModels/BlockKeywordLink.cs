using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace master_backend.Models.ModelImplementations.BlockModels;

public class BlockKeywordLink
{
    [Key]
    public long blockKeywordLinkId { get; set; }
    
    [Required]
    public long blockId { get; set; }
    
    [Required]
    public long blockKeywordId { get; set; }
    
    [ForeignKey(nameof(blockId))]
    public Block? block { get; set; }
    
    [ForeignKey(nameof(blockKeywordId))]
    public BlockKeyword? BlockKeyword { get; set; }
}