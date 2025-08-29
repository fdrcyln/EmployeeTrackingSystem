using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Employee : IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string NationalId { get; set; }
        public DateTime BirthDate { get; set; }
        public int Id { get; set; }
        public int? Salary { get; set; }
        public string Gender { get; set; }
        public DateTime? CreateDate { get; set; } 
        public DateTime? UpdateDate { get; set; } 


    }
}
