using System.ComponentModel.DataAnnotations;
using NpgsqlTypes;

namespace master_backend.Models.ModelImplementations.FuzzyModels;

public class CompanyWeight
{
    [Key]
    public long companyWeightId { get; set; }
    
    [Required]
    public NpgsqlTsVector companyWeights { get; set; }
}