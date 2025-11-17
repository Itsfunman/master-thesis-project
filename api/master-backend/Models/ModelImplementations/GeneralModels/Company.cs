using System.ComponentModel.DataAnnotations;

namespace master_backend.Models.ModelImplementations.GeneralModels;

public class Company
{
    [Key]
    public long CompanyId { get; set; }
    [Required, StringLength(200)]
    public string CompanyName { get; set; } = string.Empty;
}