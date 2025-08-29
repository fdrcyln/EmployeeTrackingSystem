using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBranchDal : EfEntityRepostoryBase<Branch, EmployeeContext>, IBranchDal
    {
        public List<BranchDetailDTO> GetBranches()
        {
            using (EmployeeContext context = new EmployeeContext())
            {
                var result = (from b in context.Branchs
                              select new BranchDetailDTO
                              {
                                  BranchId = b.Id,
                                  Adress = b.Address,
                                  Name = b.Name
                              }).ToList();
                return result;
            }
        }
    }
}
