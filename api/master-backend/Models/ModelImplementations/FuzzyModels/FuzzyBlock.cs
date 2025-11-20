using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using master_backend.Models.ModelImplementations.BlockModels;
using NpgsqlTypes;

namespace master_backend.Models.ModelImplementations.FuzzyModels;

public class FuzzyBlock
{
    [Key]
    public long fuzzyBlockId { get; set; }
    
    [Required]
    public long blockId { get; set; }
    
    [Required]
    public NpgsqlTsVector businessAllignments { get; set; }
    
    [Required]
    public NpgsqlTsVector departmentAllignments { get; set; }
    
    [ForeignKey(nameof(blockId))]
    public Block? block { get; set; }
}