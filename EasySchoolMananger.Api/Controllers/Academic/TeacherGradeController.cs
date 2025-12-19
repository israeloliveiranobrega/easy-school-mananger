using EasySchoolManager.Api.DTOs.Pedagogical.TeacherGrade.RequestDTO;
using EasySchoolManager.Api.DTOs.User.RequestDTO;
using EasySchoolManager.Api.DTOs.User.ResponseDTO;
using EasySchoolManager.Application.Services.Implementations.Academic.TeacherGrade;
using EasySchoolManager.Infra;
using EasySchoolManager.Model.Domain.Pedagogical;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EasySchoolManager.Api.Controllers.Academic
{
    [ApiController]
    [Route("easyschool/[controller]")]
    public class TeacherGradeController(DataBaseContext dataBaseContext) : ControllerBase
    {
        private readonly DataBaseContext _context = dataBaseContext;

        #region PostRegion

        [HttpPost()]
        public async Task<IActionResult> Create([FromBody] CreateTeacherGradeDTO gradeDTO)
        {
            var newGrade = new TeacherGrade
            {
                TeacherId = gradeDTO.TeacherId,
                ClassId = gradeDTO.ClassId,
                WeekDay = gradeDTO.WeekDay,
                ClassTime = gradeDTO.ClassTime
            };

            await _context.TeacherGrades.AddAsync(newGrade);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = newGrade.Id}, newGrade);
        }

        #endregion

        #region GetRegion

        [HttpGet()]
        public async Task<IActionResult> GetAll([FromQuery] bool active = true)
        {
            var query = _context.TeacherGrades.AsNoTracking().AsQueryable();

            if (active)
                query = query.Where(c => !c.IsDeleted);

            var result = await query
                .Select(c => new CreateTeacherGradeDTO(
                    c.TeacherId,
                    c.ClassId,
                    c.WeekDay,
                    c.ClassTime
                    )).ToListAsync();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var customer = await _context.TeacherGrades
               .AsNoTracking()
               .Where(c => c.Id == id)
               .Select(c => new CreateTeacherGradeDTO(
                    c.TeacherId,
                    c.ClassId,
                    c.WeekDay,
                    c.ClassTime
                   )).FirstOrDefaultAsync();

            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        #endregion

        #region PutRegion


        #endregion

        #region PatchRegion


        #endregion

        #region DeleteRegion

        #endregion
    }
}
