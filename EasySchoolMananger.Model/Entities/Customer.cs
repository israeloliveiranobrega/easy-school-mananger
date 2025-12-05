using EasySchoolMananger.Model.Base;

namespace EasySchoolMananger.Model.Entities;

public class Customer : BaseMetaData
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Password { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public DateOnly RegistrationDate { get; set; }
}
