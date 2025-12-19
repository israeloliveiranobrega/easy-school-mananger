namespace EasySchoolManager.Api.Services.Interfaces
{
    public interface IUserServices
    {
        Task<string> EncryptPassword(string password); 
        Task<bool> VerifyPassword(string userPassword, string hash); 
    }
}
