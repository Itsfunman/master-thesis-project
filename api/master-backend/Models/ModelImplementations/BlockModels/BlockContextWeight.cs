using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace master_backend.Models.ModelImplementations.BlockModels;

public class BlockContextWeight
{
    [Key]
    public long blockContextWeightId { get; set; }
    
    [Required]
    public long baseBlockId { get; set; }
    
    [Required]
    public long connectedBlockId { get; set; }

    [Required] 
    public int timesConnected { get; set; } = 0;
    
    [ForeignKey(nameof(baseBlockId))]
    public Block? baseBlock { get; set; }
    
    [ForeignKey(nameof(connectedBlockId))]
    public Block? connectedBlock { get; set; }
}