using EasySchoolManager.Model.Base.ValueObjects;

namespace EasySchoolManager.Api.DTOs.Apprentices.ResponseDTO.SchoolClass
{
    public record ResponseCompleteSchoolClassDTO(ClassGrade ClassGrade, ClassLetter ClassLetter, DateTime CreatedDate, bool IsDeleted);
}
