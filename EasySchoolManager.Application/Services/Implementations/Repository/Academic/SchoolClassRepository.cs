using EasySchoolManager.Api.Services.Interfaces.Repository;
using EasySchoolManager.Model.Domain.Academic;

namespace EasySchoolManager.Api.Services.Implementations.Repository;

public class SchoolClassRepository : ISchoolClassRepository
{
    public async Task<SchoolClass> Create()
    {
        throw new NotImplementedException();
    }

    public Task<SchoolClass> Create(SchoolClass newObject)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteBy(int id, int whoDeleted)
    {
        throw new NotImplementedException();
    }

    public async Task<ICollection<SchoolClass>> ReadAll(bool active)
    {
        throw new NotImplementedException();
    }

    public async Task<SchoolClass> ReadById(int id)
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
}
