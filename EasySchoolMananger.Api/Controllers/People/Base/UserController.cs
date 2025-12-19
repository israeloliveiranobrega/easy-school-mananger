using EasySchoolManager.Api.DTOs.User.RequestDTO;
using EasySchoolManager.Api.DTOs.User.ResponseDTO;
using EasySchoolManager.Api.Services.Implementations;
using EasySchoolManager.Api.Services.Interfaces;
using EasySchoolManager.Api.Services.Interfaces.Repository;
using EasySchoolManager.Model.Domain.People.Base;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EasySchoolManager.Api.Controllers.User
{
    [ApiController]
    [Route("easyschool/[controller]")]
    public class UserController(IUserRepository customerRepository, ILogger<UserController> logger, IUserServices customerServices) : ControllerBase
    {
        private readonly IUserServices _customerServices = customerServices;
        private readonly IUserRepository _customer = customerRepository;
        private readonly ILogger<UserController> _log = logger;

        #region PostRegion

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserDTO customer)
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

            return CreatedAtAction(nameof(GetById), new { id = newCustomer.Id}, newCustomer);
        }

        #endregion

        #region GetRegion

        [HttpGet()]
        public async Task<IActionResult> GetAll([FromQuery] bool active = true)
        {
            var query = await _customer.ReadAllAsync(active);

            var result = query.Select(c => new ResponseCompleteUserDTO(
                c.FirstName,
                c.LastName,
                c.DateOfBirth,                    
                c.CreateDate,
                c.IsDeleted));

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = await _customer.ReadByIdAsync(id);

            if (query is null)
                return NotFound();

            var result = new ResponseCompleteUserDTO(
                query.FirstName,
                query.LastName,
                query.DateOfBirth,
                query.CreateDate,
                query.IsDeleted);

            return Ok(result);
        }

        #endregion

        #region PatchRegion

        [HttpPatch("{id}/change-name")]
        public async Task<IActionResult> ChangeNameById(Guid id, ChangeNameDTO nameDTO)
        {
            int rows = await _customer.UpdateAsync(id, nameDTO.FirstName, nameDTO.LastName, nameDTO.UpdatedBy);

            if(rows == 0)
                return NotFound();

            return NoContent();
        }

        [HttpPatch("{id}/change-email")]
        public async Task<IActionResult> ChangeEmailById(Guid id, ChangeEmailDTO emailDTO)
        {
            if (await _customer.CheckSameEmail(emailDTO.Email))
                return Conflict("This email address is already registered in the system");

            int rows = await _customer.UpdateAsync(id, emailDTO.Email, emailDTO.UpdatedBy);

            if (rows == 0)
                return NotFound();

            return NoContent();
        }

        [HttpPatch("{id}/change-phone")]
        public async Task<IActionResult> ChangePhoneById(Guid id, ChangePhoneDTO phoneDTO)
        {
            string phone = $"{phoneDTO.CountryCode.Trim()}{phoneDTO.AreaCode.Trim()}{phoneDTO.SubscriberNumber.Trim()}";

            if (await _customer.CheckSamePhone(phone))
                return Conflict("This phone number is already registered in the system");

            int rows = await _customer.UpdateAsync(id, phone, phoneDTO.UpdatedBy);

            if (rows == 0)
                return NotFound();

            return NoContent();
        }

        [HttpPatch("{id}/change-password")]
        public async Task<IActionResult> ChangePasswordById(Guid id, ChangePasswordDTO passwordDTO)
        {
            if (await _customerServices.VerifyPassword(passwordDTO.OldPassword, await _customer.GetPasswordHash(id)))
                return BadRequest();

            string password = await _customerServices.EncryptPassword(passwordDTO.NewPassword);

            int rows = await _customer.UpdateAsync(id, password, passwordDTO.UpdatedBy);

            if (rows == 0)
                return NotFound();

            return NoContent();
        }

        [HttpPatch("{id}/change-date-of-birth")]
        public async Task<IActionResult> ChangeDateOfBirthById(Guid id, ChangeDateOfBirthDTO dateOfBirthDTO)
        {
            int rows = await _customer.UpdateAsync(id, dateOfBirthDTO.DateOfBirth, dateOfBirthDTO.UpdatedBy);

            if (rows == 0)
                return NotFound();

            return NoContent();
        }

        [HttpPatch("{id}/restore")]
        public async Task<IActionResult> RestoreById(Guid id, Guid whoRestored)
        {
            int rows = await _customer.RestoreByAsync(id, whoRestored);

            if (rows == 0)
                return NotFound();

            return NoContent();
        }

        #endregion

        #region DeleteRegion

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(Guid id, Guid whoDeleted)
        {
            int rows = await _customer.DeleteByAsync(id, whoDeleted);

            if (rows == 0)
                return NotFound();

            return NoContent();
        }

        #endregion
    }
}
