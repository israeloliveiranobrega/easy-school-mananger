using System;
using System.Collections.Generic;
using System.Text;

namespace EasySchoolManager.Model.Domain.Security
{
    public class Session 
    {
        public Guid Id { get; set; } = Guid.CreateVersion7();
        public Guid CustomerId { get; set; } 
    }
}
