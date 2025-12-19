using EasySchoolManager.Model.Base.ValueObjects;

namespace EasySchoolManager.Api.DTOs.Pedagogical.Teacher.RequestDTO
{
    public record RegisterTeacherDTO(Guid customerId,TeacherType TeacherType, Schedule Schedule, DateOnly? AdmissionDate);
}
