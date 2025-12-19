using EasySchoolManager.Model.Base;
using EasySchoolManager.Model.Base.ValueObjects;
using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace EasySchoolManager.Model.Domain.Academic
{
    public class TeacherGrade : BaseEntity
    {
        public Guid TeacherId { get; set; }
        public Guid ClassId { get; set; }
        public WeekDay WeekDay { get; set; }
        public TimeOnly ClassTime { get; set; }
    }
}
