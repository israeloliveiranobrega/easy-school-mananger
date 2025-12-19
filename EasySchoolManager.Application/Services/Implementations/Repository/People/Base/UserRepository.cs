//Uma molécula de DNA... ela é uma molécula pequena ou grande pessoal?
//Gente, ela não é pequena, nem grande. O que que ela é?
//ENOORMEE aaarrgghhhhhhhhhh, ELÁ É GIGANTESCA GALERA!!!

using EasySchoolManager.Api.Services.Interfaces.Repository;
using EasySchoolManager.Infra;
using EasySchoolManager.Model.Domain.People.Base;
using Microsoft.Extensions.Logging;

namespace EasySchoolManager.Api.Services.Implementations.Repository;

public class UserRepository(DataBaseContext dataBase, ILogger<UserRepository> logger) : BaseRepository<User>(dataBase), IUserRepository
{
    private readonly ILogger<UserRepository> _log = logger;

    public Task<DateOnly> GetBirth(Guid Id)
    {
        throw new NotImplementedException();
    }

    public Task<string> GetEmail(Guid Id)
    {
        throw new NotImplementedException();
    }

    public Task<(string, string)> GetName(Guid Id)
    {
        throw new NotImplementedException();
    }

    public Task<string> GetPasswordHash(Guid Id)
    {
        throw new NotImplementedException();
    }

    public Task<string> GetPhone(Guid Id)
    {
        throw new NotImplementedException();
    }

    public Task<DateOnly> GetRegistration(Guid Id)
    {
        throw new NotImplementedException();
    }
}