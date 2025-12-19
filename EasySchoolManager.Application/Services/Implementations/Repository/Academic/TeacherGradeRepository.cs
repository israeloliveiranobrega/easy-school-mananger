using EasySchoolManager.Api.Services.Interfaces.Repository;
using EasySchoolManager.Model.Domain.Academic;

namespace EasySchoolManager.Api.Services.Implementations.Repository;

public class TeacherGradeRepository : ITeacherGradeRepository
{
    public Task<TeacherGrade> Create(TeacherGrade newObject)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteBy(Guid id, Guid whoDeleted)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TeacherGrade>> ReadAll(bool active = true)
    {
        throw new NotImplementedException();
    }

    public Task<TeacherGrade?> ReadById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<int> RestoreBy(Guid id, Guid whoRestored)
    {
        throw new NotImplementedException();
    }
}
