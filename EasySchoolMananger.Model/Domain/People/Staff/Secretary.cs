using EasySchoolManager.Model.Base;

namespace EasySchoolManager.Model.Domain.People.Staff;

public class Secretary : BaseEntity
{
    public DateOnly? AdmissionDate { get; set; }
}
