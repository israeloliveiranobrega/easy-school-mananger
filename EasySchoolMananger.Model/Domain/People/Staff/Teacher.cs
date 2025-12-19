using EasySchoolManager.Model.Base;
using EasySchoolManager.Model.Base.ValueObjects;

namespace EasySchoolManager.Model.Domain.People.Staff;

public class Teacher : BaseEntity
{
    public TeacherType TeacherType { get; set; }
    public Schedule Schedule { get; set; }
    public DateOnly? AdmissionDate { get; set; }
}
