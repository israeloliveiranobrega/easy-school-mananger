using EasySchoolManager.Model.Domain.People.Base;

namespace EasySchoolManager.Api.Services.Interfaces.Repository
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<(string,string)> GetName(Guid Id);
        Task<string> GetEmail(Guid Id);
        Task<string> GetPhone(Guid Id);
        Task<string> GetPasswordHash(Guid Id);
        Task<DateOnly> GetBirth(Guid Id);
        Task<DateOnly> GetRegistration(Guid Id);
    }
}
