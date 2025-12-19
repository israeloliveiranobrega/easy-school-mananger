using EasySchoolManager.Api.Services.Interfaces.Repository;
using EasySchoolManager.Model.Base.ValueObjects;
using EasySchoolManager.Model.Domain.People.Staff;

namespace EasySchoolManager.Api.Services.Implementations.Repository;

public class TeacherRepository : ITeacherRepository
{
    public Task<Teacher> Create(Teacher newObject)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteBy(Guid id, Guid whoDeleted)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Teacher>> ReadAll(bool active = true)
    {
        throw new NotImplementedException();
    }

    public Task<Teacher?> ReadById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<int> RestoreBy(Guid id, Guid whoRestored)
    {
        throw new NotImplementedException();
    }

    public Task<int> UpdateSchedule(int id, Schedule schedule, int whoEdited)
    {
        throw new NotImplementedException();
    }

    public Task<int> UpdateType(int id, TeacherType teacherType, int whoEdited)
    {
        throw new NotImplementedException();
    }
}
