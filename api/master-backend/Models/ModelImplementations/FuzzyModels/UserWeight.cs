using System.ComponentModel.DataAnnotations;
using NpgsqlTypes;

namespace master_backend.Models.ModelImplementations.FuzzyModels;

public class UserWeight
{
    [Key]
    public long userWeightId { get; set; }
    
    [Required]
    public NpgsqlTsVector userWeights { get; set; }
}