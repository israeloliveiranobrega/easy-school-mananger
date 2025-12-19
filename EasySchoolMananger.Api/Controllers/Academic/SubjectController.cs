using EasySchoolManager.Api.DTOs.Apprentices.RequestDTO.Matter;
using EasySchoolManager.Infra;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EasySchoolManager.Api.Controllers.Academic
{
    [ApiController]
    [Route("easyschool/[controller]")]
    public class SubjectController(DataBaseContext dataBaseContext) : ControllerBase
    {
        private readonly DataBaseContext _context = dataBaseContext;

        #region PostRegion

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSubjectDTO matterDTO)
        {
            var newMatter = new Subject()
            {
                TeacherId = matterDTO.TeacherId,
                MatterList = matterDTO.MatterList,
                Other = matterDTO.Other
            };

            await _context.Matters.AddAsync(newMatter);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = newMatter.Id},newMatter);
        }

        #endregion

        #region GetRegion

        [HttpGet()]
        public async Task<IActionResult> GetAll([FromQuery] bool active = true)
        {
            var query = _context.Matters.AsNoTracking().AsQueryable();

            if (active)
                query = query.Where(x => !x.IsDeleted);

            var result = await _context.Matters
                .Select(x => new CreateSubjectDTO(
                    x.TeacherId,
                    x.MatterList,
                    x.Other
                    )).ToListAsync();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var matter = await _context.Matters
                .AsNoTracking()
                .Where(x => x.Id == id)
                .Select(x => new CreateSubjectDTO(
                    x.TeacherId,
                    x.MatterList,
                    x.Other
                    )).FirstOrDefaultAsync();

            return Ok();
        }

        #endregion

        #region PatchRegion

        [HttpPatch("{id}/restore")]
        public async Task<IActionResult> RestoreById(Guid id)
        {
            var matter = await _context.Matters.FirstOrDefaultAsync(m => m.Id == id);

            if (matter == null)
                return NotFound();

            if (matter.IsDeleted == false)
                return BadRequest("This matter does not deleted");

            matter.IsDeleted = false;
            matter.DeletedBy = null;
            matter.DeletedDate = null;

            return NoContent();
        }

        #endregion

        #region DeletetRegion

        [HttpDelete]
        public async Task<IActionResult> DeleteById(Guid id, Guid userId)
        {
            var matter = await _context.Matters.FirstOrDefaultAsync(m => m.Id == id);

            if (matter == null)
                return NotFound();

            if (matter.IsDeleted == true)
                return BadRequest("This matter it's already deleted");

            matter.IsDeleted = true;
            matter.DeletedBy = userId;
            matter.DeletedDate = DateTime.UtcNow;

            return NoContent();
        }

        #endregion
    }
}
