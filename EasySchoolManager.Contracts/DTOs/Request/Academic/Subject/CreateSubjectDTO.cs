using EasySchoolManager.Model.Base.ValueObjects;

namespace EasySchoolManager.Api.DTOs.Apprentices.RequestDTO.Matter
{
    public record CreateSubjectDTO(Guid TeacherId, MatterList MatterList, string? Other);
}
