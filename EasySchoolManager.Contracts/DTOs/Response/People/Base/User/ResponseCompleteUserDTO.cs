namespace EasySchoolManager.Api.DTOs.User.ResponseDTO
{
    public record ResponseCompleteUserDTO(
        string FirstName, 
        string LastName, 
        DateOnly? DateOfBirth, 
        DateTime CreationDate, 
        bool IsDeleted);
}
