using EasySchoolManager.Model.Base.ValueObjects;

namespace EasySchoolManager.Api.DTOs.Apprentices.RequestDTO.Student
{
    public record RegisterStudentDTO(
        string FirstName,
        string LastName, 
        DateOnly DateOfBirth, 
        Schedule Schedule, 
        Guid ClassId, 
        Condition Condition = 0 ,
        bool IsPCD = false, 
        DisabilityType DisabilityType = 0,
        AttentionLevel AttentionLevel = 0);
}
