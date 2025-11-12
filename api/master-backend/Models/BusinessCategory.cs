using System.ComponentModel.DataAnnotations;

namespace master_backend.Models;

public class BusinessCategory
{
    [Key]
    public long BusinessCategoryID { get; set; }

    [Required, StringLength(200)]
    public string BusinessCategoryName { get; set; } = string.Empty;
}