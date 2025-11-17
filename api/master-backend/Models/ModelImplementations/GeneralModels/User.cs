using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace master_backend.Models.ModelImplementations.GeneralModels;

public class User
{
    [Key]
    public long UserId { get; set; }

    [Required]
    public long CompanyId { get; set; }
    [Required]
    public long? DepartmentCategoryId { get; set; }
    [Required]
    public long? BusinessCategoryId { get; set; }

    [Required, EmailAddress, MaxLength(100)]
    public string Email { get; set; } = string.Empty;

    [Required, StringLength(100)]
    public string DisplayName { get; set; } = string.Empty;

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [ForeignKey(nameof(CompanyId))]
    public Company? Company { get; set; }

    [ForeignKey(nameof(DepartmentCategoryId))]
    public DepartmentCategory? DepartmentCategory { get; set; }

    [ForeignKey(nameof(BusinessCategoryId))]
    public BusinessCategory? BusinessCategory { get; set; }
}