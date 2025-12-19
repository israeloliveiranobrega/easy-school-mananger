using EasySchoolManager.Model.Base;
using EasySchoolManager.Model.Base.ValueObjects;

namespace EasySchoolManager.Model.Domain.People.Students;

public class Student : BaseEntity
{
    //sobre o alun
    public Guid ClassID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly DateOfBirth { get; set; }

    //estado atual do aluno
    public Schedule Schedule { get; set; }
    public Condition Condition { get; set; }

    //estatísticas do aluno
    public int Occurrences { get; set; }
    public int Highlights { get; set; }

    //deficiências e necessidades especiais
    public bool IsPCD { get; set; }
    public DisabilityType DisabilityType { get; set; }
    public AttentionLevel AttentionLevel { get; set; }

    //data de registro do aluno
    public DateOnly RegistrationDate { get; set; }
}
