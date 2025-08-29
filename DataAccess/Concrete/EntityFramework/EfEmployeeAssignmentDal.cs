using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfEmployeeAssignmentDal : EfEntityRepostoryBase<EmployeeAssignment, EmployeeContext>, IEmployeeAssignmentDal
    {
        public List<EmployeeAssignmentDetailDTO> GetAssignmentDetails()
        {
            using var context = new EmployeeContext();

            var query = from ea in context.EmployeeAssignments
                        join e in context.Employees on ea.EmployeeId equals e.Id
                        join p in context.Positions on ea.PositionId equals p.Id
                        join d in context.Departments on ea.DepartmentId equals d.Id
                        join b in context.Branchs on d.BranchId equals b.Id
                        select new EmployeeAssignmentDetailDTO
                        {
                            Id = ea.Id,
                            EmployeeId = e.Id,
                            EmployeeFullName = e.FirstName + " " + e.LastName,
                            DepartmentId = d.Id,
                            DepartmentName = d.Name,
                            PositionId = p.Id,
                            PositionName = p.Name,
                            BranchId = b.Id,
                            BranchName = b.Name,
                            HireDate = ea.HireDate,
                            TerminationDate = ea.TerminationDate,
                            CreateDate = ea.CreateDate,
                            UpdateDate = ea.UpdateDate
                        };
            return query.AsNoTracking().ToList();
        }
    }
}
