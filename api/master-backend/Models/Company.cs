using System.ComponentModel.DataAnnotations;

namespace master_backend.Models;

public class Company
{
    [Key]
    public long CompanyId { get; set; }
    [Required, StringLength(200)]
    public string CompanyName { get; set; } = string.Empty;
}