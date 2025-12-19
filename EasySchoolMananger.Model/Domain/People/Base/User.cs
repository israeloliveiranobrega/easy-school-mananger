using EasySchoolManager.Model.Base;

namespace EasySchoolManager.Model.Domain.People.Base;

public class User : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Password { get; set; }
    public DateOnly? DateOfBirth { get; set; }
    public DateOnly RegistrationDate { get; set; }
}
