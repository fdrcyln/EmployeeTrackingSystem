
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Branch : IEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Id { get; set; }
        public DateTime? CreateDate { get; set; }  // Default to current date
        public DateTime? UpdateDate { get; set; }  // Default to current date
    }
}
