using EasySchoolManager.Model.Base;
using EasySchoolManager.Model.Base.ValueObjects;

namespace EasySchoolManager.Model.Domain.Academic;

public class Subject : BaseEntity
{
    public Guid TeacherId { get; set; }
    public MatterList MatterList { get; set; }
    public string? Other { get; set; }
}
