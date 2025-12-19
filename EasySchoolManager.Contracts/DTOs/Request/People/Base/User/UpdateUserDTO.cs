using EasySchoolManager.Api.DTOs.Utils.Validations;

namespace EasySchoolManager.Api.DTOs.User.RequestDTO
{
    public record UpdateUserDTO(
        [CheckFirstName]    
        string? FirstName,
        [CheckLastName]
        string? LastName,
        [CheckEmail]
        string? Email,
        [CheckCountryCode]
        string? CountryCode,
        [CheckAreaCode]
        string? AreaCode,
        [CheckSubscriberNumber]
        string? SubscriberNumber,
        [CheckPassword]
        string? Password,
        DateOnly? DateOfBirth);
}
