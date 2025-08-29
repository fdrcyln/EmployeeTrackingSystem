using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    internal class PositionDetailDTO : IDto
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public int DepartmantId { get; set; }
        public int Id { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
