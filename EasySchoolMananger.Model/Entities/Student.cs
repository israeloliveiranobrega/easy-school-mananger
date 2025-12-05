using EasySchoolMananger.Model.Base;

namespace EasySchoolMananger.Model.Entities;

public class Student : BaseMetaData
{
    public string Name { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public DateOnly RegistrationDate { get; set; }
    public Condition Condition { get; set; }
    public int Occurrences { get; set; }
    public int Highlights { get; set; }
    public bool IsPCD { get; set; }
    public DisabilityType DisabilityType { get; set; }
    public AttentionLevel AttentionLevel { get; set; }
}
