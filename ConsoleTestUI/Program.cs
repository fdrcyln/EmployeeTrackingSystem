using Business.Concrete;
using Business.ValidationRules.FluentValidation;
using DataAccess.Concrete.EntityFramework;
using FluentValidation;
using Entities.Concrete;

class Program
{
    static void Main(string[] args)
    {
        var assignmentDal = new EfEmployeeAssignmentDal();
        IValidator<EmployeeAssignment> validator = new EmployeeAssignmentValidator();
        var manager = new EmployeeAssignmentManager(assignmentDal, validator);

        var result = manager.GetAll();
        if (result.Success && result.Data != null)
        {
            foreach (var item in result.Data)
            {
                Console.WriteLine($"Assignment ID: {item.Id}, Department: {item.DepartmentId}");
            }
        }
        else
        {
            Console.WriteLine(result.Message);
        }
    }
}
