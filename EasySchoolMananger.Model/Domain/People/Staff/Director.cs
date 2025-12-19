using EasySchoolManager.Model.Base;
using EasySchoolManager.Model.Base.ValueObjects;

namespace EasySchoolManager.Model.Domain.People.Staff;

public class Director : BaseEntity
{
    public Schedule ServiceHours { get; set; }
    public DateOnly? AdmissionDate { get; set; }
}
