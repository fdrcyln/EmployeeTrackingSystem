using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class EmployeeAssignment : IEntity
    {
        public int EmployeeId { get; set; }
        public int DepartmentId { get; set; }
        public int PositionId { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime? TerminationDate { get; set; }
        public int Id { get ; set; }
        public DateTime? CreateDate { get; set; }  // Default to current date
        public DateTime? UpdateDate { get; set; } // Default to current date
    }
}
