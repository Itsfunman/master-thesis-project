using System.ComponentModel.DataAnnotations;

namespace master_backend.Models.ModelImplementations.GeneralModels;

public class DepartmentCategory
{
    [Key]
    public long DepartmentCategoryID { get; set; }

    [Required, StringLength(200)]
    public string DepartmentCategoryName { get; set; } = string.Empty;
}