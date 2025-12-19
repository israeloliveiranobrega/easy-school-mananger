using EasySchoolManager.Model.Base;
using EasySchoolManager.Model.Base.ValueObjects;

namespace EasySchoolManager.Model.Domain.People.Staff;

public class Coordinator : BaseEntity
{
    public Schedule ServiceHours { get; set; }
    public DateOnly? AdmissionDate { get; set; }
}
