using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfDepartmenDal : EfEntityRepostoryBase<Department, EmployeeContext>, IDepartmentDal
    {
        public List<DepartmentDetailDTO> GetDepartmants()
        {
            using (EmployeeContext context = new EmployeeContext())
            {
                var result = (from d in context.Departments
                              select new DepartmentDetailDTO
                              {
                                  Id = d.Id,
                                  Name = d.Name,
                                  BranchId = d.BranchId,
                                  CreateDate = d.CreateDate,
                                  UpdateDate = d.UpdateDate
                              }).ToList();
                return result;
            }

            using (EmployeeContext context = new EmployeeContext())
            {
                var result = (from d in context.Departments
                              join b in context.Branchs on d.BranchId equals b.Id
                              select new DepartmentDetailDTO
                              {
                                  Id= d.Id,
                                  Name = d.Name,
                                  BranchId = b.Id,
                                  BranchName=b.Name

                              }).ToList();
            }
        }
    }
}
