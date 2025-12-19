using EasySchoolManager.Model.Base;
using EasySchoolManager.Model.Base.ValueObjects;

namespace EasySchoolManager.Model.Domain.Academic;

public class SchoolClass : BaseEntity
{
    public ClassGrade ClassGrade { get; set; }
    public ClassLetter ClassLetter { get; set; }    
}
