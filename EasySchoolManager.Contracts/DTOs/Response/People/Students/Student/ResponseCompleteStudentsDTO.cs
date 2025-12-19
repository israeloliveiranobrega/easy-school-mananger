using EasySchoolManager.Model.Base.ValueObjects;

namespace EasySchoolManager.Api.DTOs.Apprentices.ResponseDTO.Student
{
    public record ResponseCompleteStudentsDTO(string FirstName,string LastName, DateOnly DateOfBirth, Schedule Schedule, Guid ClassId ,int Occurrences ,int Highlights, Condition Condition = 0, bool IsPCD = false, DisabilityType DisabilityType = 0, AttentionLevel AttentionLevel = 0);
}
