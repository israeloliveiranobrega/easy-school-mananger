using EasySchoolManager.Api.DTOs.Pedagogical.Teacher.RequestDTO;
using EasySchoolManager.Api.DTOs.Pedagogical.Teacher.ResponseDTO;
using EasySchoolManager.Api.DTOs.Utils.ChangeDTOs;
using EasySchoolManager.Application.Services.Implementations.People.Staff.Teacher;
using EasySchoolManager.Infra;
using EasySchoolManager.Model.Domain.People.Staff;
using EasySchoolManager.Model.Domain.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.EntityFrameworkCore;

namespace EasySchoolManager.Api.Controllers.People.Staff
{
    [ApiController]
    [Route("easyschool/[controller]")]
    public class TeacherController(DataBaseContext dataBaseContext) : ControllerBase
    {
        private readonly DataBaseContext _context = dataBaseContext;

        #region PostRegion

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RegisterTeacherDTO teacherDTO)
        {
            var customer = await _context.Customers.AnyAsync(c => c.Id == teacherDTO.customerId);

            if (!customer)
                return BadRequest($"This customer with id:{teacherDTO.customerId} does not exist");

            var teacher = await _context.Teachers.AnyAsync(c => c.Id == teacherDTO.customerId);

            if (teacher)
                return BadRequest($"This teacher with id:{teacherDTO.customerId} already exist");

            var NewTeacher = new Teacher()
            {
                Id = teacherDTO.customerId,
                TeacherType = teacherDTO.TeacherType,
                Schedule = teacherDTO.Schedule,
                AdmissionDate = teacherDTO.AdmissionDate,
            };

            await _context.Teachers.AddAsync(NewTeacher);

            await _context.SaveChangesAsync();  

            return CreatedAtAction(nameof(GetById), new { id = NewTeacher.Id}, NewTeacher);
        }
        #endregion

        #region GetRegion

        [HttpGet()]
        public async Task<IActionResult> GetAll([FromQuery] bool active = true)
        {
            var query = _context.Teachers.AsNoTracking().AsQueryable();

            if (active)
                query = query.Where(t => !t.IsDeleted);

            var result = await query
                .Select(t => new ResponseCompleteTeacherDTO(

                    )).ToListAsync();

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var teacher = await _context.Teachers
                .AsNoTracking()
                .Where(c => c.Id == id)
                .Select(c => new ResponseCompleteTeacherDTO(
                    


                    )).FirstOrDefaultAsync();

            if (teacher is null)
                return BadRequest($"This teacher with id:{id} does not exist");

            return Ok(teacher);
        }

        #endregion

        #region PatchRegion

        [HttpPatch("{id}/change-teacher-type")]
        public async Task<IActionResult> ChangeTeacherTypeById(Guid id, ChangeTeacherTypeDTO teacherTypeDTO)
        {
            var teacher = await _context.Teachers.FirstOrDefaultAsync(t => t.Id == id);

            if (teacher is null)
                return NotFound();

            if (teacher.IsDeleted == true)
                return BadRequest("This teacher is deleted");

            teacher.TeacherType = teacherTypeDTO.TeacherType;
            UpdateAudit(teacher,teacherTypeDTO.UpdatedBy);

            return NoContent();
        }


        [HttpPatch("{id}/change-schedule")]
        public async Task<IActionResult> RestoreScheduleById(Guid id, ChangeScheduleDTO scheduleDTO)
        {
            var teacher = await _context.Teachers.FirstOrDefaultAsync(t => t.Id == id);

            if (teacher is null)
                return NotFound();

            if (teacher.IsDeleted == true)
                return BadRequest("This teacher is deleted");

            teacher.Schedule = scheduleDTO.Schedule;
            UpdateAudit(teacher, scheduleDTO.UpdatedBy);

            return NoContent();
        }


        [HttpPatch("{id}/restore")]
        public async Task<IActionResult> RestoreById(Guid id)
        {
            var teacher = await _context.Teachers.FirstOrDefaultAsync(t => t.Id == id);

            if (teacher is null)
                return NotFound();

            if (teacher.IsDeleted == true)
                return BadRequest("This teacher it's already deleted");

            teacher.IsDeleted = true;
            teacher.DeletedBy = null;
            teacher.DeletedDate = null;

            return NoContent();
        }

        #endregion

        #region DeleteRegion

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(Guid id, Guid userId)
        {
            var teacher = await _context.Teachers.FirstOrDefaultAsync(t => t.Id == id);

            if (teacher is null)
                return NotFound();

            if (teacher.IsDeleted == true)
                return BadRequest("This teacher it's already deleted");

            teacher.IsDeleted = true;
            teacher.DeletedBy = userId;
            teacher.DeletedDate= DateTime.UtcNow;

            return NoContent();
        }

        #endregion

        private void UpdateAudit(Teacher teacher, Guid whoUpdated)
        {
            teacher.LastUpdateDate = DateTime.UtcNow;
            teacher.LastUpdatedBy = whoUpdated;
        }
    }
}
