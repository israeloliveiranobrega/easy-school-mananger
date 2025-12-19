using EasySchoolManager.Model.Base.ValueObjects;

namespace EasySchoolManager.Api.DTOs.Apprentices.RequestDTO.SchoolClass
{
    public record CreateSchoolClassDTO(ClassGrade ClassGrade, ClassLetter ClassLetter);
}
