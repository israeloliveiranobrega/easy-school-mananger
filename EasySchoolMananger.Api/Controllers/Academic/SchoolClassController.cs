using EasySchoolManager.Api.DTOs.Apprentices.RequestDTO.SchoolClass;
using EasySchoolManager.Api.DTOs.Apprentices.ResponseDTO.SchoolClass;
using EasySchoolManager.Application.Services.Implementations.Academic.SchoolClass;
using EasySchoolManager.Infra;
using EasySchoolManager.Model.Domain.Apprentices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EasySchoolManager.Api.Controllers.Academic
{
    [ApiController]
    [Route("easyschool/[controller]")]
    public class SchoolClassController(DataBaseContext dataBaseContext) : ControllerBase
    {
        private readonly DataBaseContext _context = dataBaseContext;

        #region PostRegion
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSchoolClassDTO classDTO)
        {
            var newClass = new SchoolClass()
            {
                ClassGrade = classDTO.ClassGrade,
                ClassLetter = classDTO.ClassLetter
            };

            _context.SchoolClasses.Add(newClass);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = newClass.Id }, newClass);
        }

        #endregion

        #region GetRegion

        [HttpGet()]
        public async Task<IActionResult> GetAll([FromQuery] bool active = true)
        {
            var query = _context.SchoolClasses.AsNoTracking().AsQueryable();

            if (active)
                query = query.Where(c => !c.IsDeleted);

            var result = await _context.SchoolClasses
                .Select(c => new ResponseCompleteSchoolClassDTO(
                    c.ClassGrade,
                    c.ClassLetter,
                    c.CreateDate,
                    c.IsDeleted
                    )).ToListAsync();

            if (result is null)
                return NotFound();

            await _context.SaveChangesAsync();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var schoolClass = await _context.SchoolClasses
                .AsNoTracking()
                .Where(c => c.Id == id)
                .Select(c => new ResponseCompleteSchoolClassDTO(
                    c.ClassGrade,
                    c.ClassLetter,
                    c.CreateDate,
                    c.IsDeleted
                    )).FirstOrDefaultAsync();

            if (schoolClass is null)
                return NotFound("Class does not exist");

            await _context.SaveChangesAsync();

            return Ok(schoolClass);
        }

        #endregion

        #region PatchRegion

        [HttpPatch("{id}/restore")]
        public async Task<IActionResult> RestoreById(Guid id, Guid userId)
        {
            var schollClass = await _context.SchoolClasses.AsNoTracking().Where(c => c.Id == id).FirstOrDefaultAsync();

            if (schollClass is null)
                return NotFound();

            if (schollClass.IsDeleted == false)
                return BadRequest("Class is not deleted");

            schollClass.IsDeleted = false;
            schollClass.DeletedDate = null;
            schollClass.DeletedBy = null;

            await _context.SaveChangesAsync();

            return NotFound();
        }

        #endregion

        #region DeleteRegion
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(Guid id, Guid userId)
        {
            var schollClass = await _context.SchoolClasses.AsNoTracking().Where(c => c.Id == id).FirstOrDefaultAsync();

            if (schollClass is null)
                return NotFound();

            if (schollClass.IsDeleted == true)
                return BadRequest("Class it's already deleted");

            schollClass.IsDeleted = true;
            schollClass.DeletedDate = DateTime.UtcNow;
            schollClass.DeletedBy = userId;

            await _context.SaveChangesAsync();

            return NotFound();
        }

        #endregion
    }
}
