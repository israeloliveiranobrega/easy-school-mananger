using EasySchoolManager.Api.Services.Interfaces;
using EasySchoolManager.Model.Domain.People.Base;

namespace EasySchoolManager.Api.Services.Implementations;

public class UserServices : IUserServices
{
    public Task<string> EncryptPassword(string password)
    {
        string hash = BCrypt.Net.BCrypt.HashPassword(password);
        return Task.FromResult(hash);
    }

    public Task<bool> VerifyPassword(string userPassword, string hash)
    {
        bool valid = BCrypt.Net.BCrypt.Verify(userPassword, hash);
        return Task.FromResult(valid);
    }
    public Task<User> CreateUserAsync()
    {
        if (await _customer.CheckSameEmail(customer.Email))
            return Conflict("This email address is already registered in the system");

        string phone = $"{customer.CountryCode.Trim()}{customer.AreaCode.Trim()}{customer.SubscriberNumber.Trim()}";

        if (await _customer.CheckSamePhone(phone))
            return Conflict("This phone number is already registered in the system");

        string password = await _customerServices.EncryptPassword(customer.Password);

        var newCustomer = new User
        {
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            Email = customer.Email,
            Phone = phone,
            Password = password,
            DateOfBirth = customer.DateOfBirth,
        };

        //provisorio
        newCustomer.CreatedBy = Guid.CreateVersion7();

        await _customer.CreateAsync(newCustomer);
    }
}
