using EasySchoolManager.Model.Base.ValueObjects;

namespace EasySchoolManager.Api.DTOs.Pedagogical.TeacherGrade.RequestDTO
{
    public record CreateTeacherGradeDTO(Guid TeacherId, Guid ClassId, WeekDay WeekDay, TimeOnly ClassTime);
}
