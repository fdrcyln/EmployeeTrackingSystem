using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    internal class EmployeeDetailDTO : IDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string NationalId { get; set; }
        public DateTime BirthDate { get; set; }
        public int Salary { get; set; }
        public string Sender { get; set; }
        public int Id { get; set; }
        // public int salary { get; set; }
        // public string gender { get; set; }
        public DateTime? CreateDate { get; set; } // Default to current date
        public DateTime? UpdateDate { get; set; } // Default to current date
    }
}
