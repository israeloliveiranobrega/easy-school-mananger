using EasySchoolManager.Api.DTOs.Apprentices.RequestDTO.Student;
using EasySchoolManager.Api.DTOs.Apprentices.ResponseDTO.Student;
using EasySchoolManager.Api.DTOs.Utils.ChangeDTOs;
using EasySchoolManager.Application.Services.Implementations.People.Students.Student;
using EasySchoolManager.Infra;
using EasySchoolManager.Model.Domain.People.Students;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EasySchoolManager.Api.Controllers.People.Students
{
    [ApiController]
    [Route("easyschool/[controller]")]
    public class StudentController(DataBaseContext dataBaseContext) : ControllerBase
    {
        private readonly DataBaseContext _context = dataBaseContext;

        #region PostRegion
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RegisterStudentDTO studentDTO)
        {
            var newStudent = new Student()
            {
                FirstName = studentDTO.FirstName,
                LastName = studentDTO.LastName,
                DateOfBirth = studentDTO.DateOfBirth,
                Schedule = studentDTO.Schedule,
                ClassID = studentDTO.ClassId,
                Condition = studentDTO.Condition,
                IsPCD = studentDTO.IsPCD,
                DisabilityType = studentDTO.DisabilityType,
                AttentionLevel = studentDTO.AttentionLevel
            };

            _context.Students.Add(newStudent);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof (GetById), new {id = newStudent.Id}, newStudent);
        }
        #endregion

        #region GetRegion
        [HttpGet()]
        public async Task<IActionResult> GetAll([FromQuery]bool active = true)
        {
            var query = _context.Students.AsNoTracking().AsQueryable();

            if (active)
                query = _context.Students.Where(s => !s.IsDeleted);

            var result = await query.Select(s => new ResponseCompleteStudentsDTO(
                s.FirstName,
                s.LastName,
                s.DateOfBirth,
                s.Schedule,
                s.ClassID,
                s.Occurrences,
                s.Highlights,
                s.Condition,
                s.IsPCD,
                s.DisabilityType,
                s.AttentionLevel
                )).ToListAsync();

            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _context.Students
                .AsNoTracking()
                .Where(s => s.Id == id)
                .Select(s => new ResponseCompleteStudentsDTO(
                    s.FirstName,
                    s.LastName,
                    s.DateOfBirth,
                    s.Schedule,
                    s.ClassID,
                    s.Occurrences,
                    s.Highlights,
                    s.Condition,
                    s.IsPCD,
                    s.DisabilityType,
                    s.AttentionLevel
               )).FirstOrDefaultAsync();

            if (result is null)
                return NotFound("Student does not exist");

            await _context.SaveChangesAsync();

            return Ok(result);
        }
        #endregion

        #region PatchRegion

        [HttpPatch("{id}/change-name")]
        public async Task<IActionResult> ChangeNameById(Guid id, ChangeNameDTO nameDTO)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == id);

            if (student is null)
                return NotFound();

            if (student.IsDeleted == true)
                return BadRequest("This student is deleted");

            student.FirstName = nameDTO.FirstName;
            student.LastName = nameDTO.LastName;
            UpdateAudit(student, nameDTO.UpdatedBy);

            await _context.SaveChangesAsync();
    
            return NoContent();
        }
        [HttpPatch("{id}/change-date-of-birth")]
        public async Task<IActionResult> ChangeDateOfBirthById(Guid id, ChangeDateOfBirthDTO dateOfBirthDTO)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == id);

            if (student is null)
                return NotFound();

            if (student.IsDeleted == true)
                return BadRequest("This student is deleted");

            student.DateOfBirth = dateOfBirthDTO.DateOfBirth;
            UpdateAudit(student, dateOfBirthDTO.UpdatedBy);

            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpPatch("{id}/change-schedule")]
        public async Task<IActionResult> ChangeScheduleById(Guid id, ChangeScheduleDTO scheduleDTO)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == id);

            if (student is null)
                return NotFound();

            if (student.IsDeleted == true)
                return BadRequest("This student is deleted");

            student.Schedule = scheduleDTO.Schedule;
            UpdateAudit(student, scheduleDTO.UpdatedBy);

            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpPatch("{id}/change-class")]
        public async Task<IActionResult> ChangeClassById(Guid id, ChangeClassDTO classDTO)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == id);

            if (student is null)
                return NotFound();

            if (student.IsDeleted == true)
                return BadRequest("This student is deleted");

            student.ClassID = classDTO.ClassId;
            UpdateAudit(student, classDTO.UpdatedBy);

            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpPatch("{id}/change-condition")]
        public async Task<IActionResult> ChangeConditionById(Guid id, ChangeConditionDTO conditionDTO)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == id);

            if (student is null)
                return NotFound();

            if (student.IsDeleted == true)
                return BadRequest("This student is deleted");

            student.Condition = conditionDTO.condition;
            UpdateAudit(student, conditionDTO.UpdatedBy);

            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpPatch("{id}/change-pcd")]
        public async Task<IActionResult> ChangePCDById(Guid id, ChangePcdDTO pcdDTO)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == id);

            if (student is null)
                return NotFound();

            if (student.IsDeleted == true)
                return BadRequest("This student is deleted");

            student.IsPCD = pcdDTO.IsPcd;
            student.DisabilityType = pcdDTO.DisabilityType;
            student.AttentionLevel = pcdDTO.AttentionLevel;
            UpdateAudit(student, pcdDTO.UpdatedBy);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPatch("{id}/restore")]
        public async Task<IActionResult> RestoreById(Guid id, int userId)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == id);

            if (student is null)
                return NotFound();

            if (student.IsDeleted == false)
                return BadRequest("This student is not deleted");

            student.IsDeleted = false;
            student.DeletedBy = null;
            student.DeletedDate = null;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        #endregion

        #region DeleteRegion

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(Guid id, Guid userId)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == id);

            if (student is null)
                return NotFound();

            if (student.IsDeleted == true)
                return BadRequest("This student it's already deleted");

            student.IsDeleted = true;
            student.DeletedBy = userId;
            student.DeletedDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        #endregion

        private void UpdateAudit(Student student, Guid whoUpdated)
        {
            student.LastUpdateDate = DateTime.UtcNow;
            student.LastUpdatedBy = whoUpdated;
        }
    }
}
