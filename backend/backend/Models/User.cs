using backend.Models;

namespace backend.FormGeneration.DatabaseAccessor.Models.GeneralDataModels;

public class User
{
    public long UserID { get; set; }
    public long CompanyID { get; set; }
    public long DepartmentID { get; set; }
    public long BusinessID { get; set; }
    
    public string Email { get; set; }
    public string DisplayName { get; set; }
    public DateTime CreatedAt { get; set; }
    
    public Company? Company { get; set; }
    public Department? Department { get; set; }
    public Business? Business { get; set; }
}