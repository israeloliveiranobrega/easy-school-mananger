using EasySchoolManager.Api.Services.Interfaces.Repository;
using EasySchoolManager.Model.Base.ValueObjects;
using EasySchoolManager.Model.Domain.People.Students;

namespace EasySchoolManager.Api.Services.Implementations.Repository;

public class StudentRepository : IStudentRepository
{
    public async Task<Student> Create()
    {
        throw new NotImplementedException();
    }

    public Task<Student> Create(Student newObject)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteBy(int id, int whoDeleted)
    {
        throw new NotImplementedException();
    }

    public async Task<ICollection<Student>> ReadAll(bool active)
    {
        throw new NotImplementedException();
    }

    public async Task<Student> ReadById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<int> RestoreBy(int id)
    {
        throw new NotImplementedException();
    }

    public Task<int> RowsCount(bool active = true)
    {
        throw new NotImplementedException();
    }

    public async Task<int> UpdateClass(int id, int classId, int whoEdited)
    {
        throw new NotImplementedException();
    }

    public async Task<int> UpdateCondition(int id, Condition condition, int whoEdited)
    {
        throw new NotImplementedException();
    }

    public async Task<int> UpdateDateOfBirth(int id, DateOnly dateOfBirth, int whoEdited)
    {
        throw new NotImplementedException();
    }

    public async Task<int> UpdateName(int id, string name, int whoEdited)
    {
        throw new NotImplementedException();
    }

    public async Task<int> UpdatePcd(int id, bool isPcd, DisabilityType disabilityType, AttentionLevel attentionLevel, int whoEdited)
    {
        throw new NotImplementedException();
    }

    public async Task<int> UpdateSchedule(int id, Schedule schedule, int whoEdited)
    {
        throw new NotImplementedException();
    }
}
