using System.Collections.Generic;

namespace FormsApp.Models
{
    // Generic wrapper aligned to IDataResult<T> returned by your WebAPI
    public class ApiResponse<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }

    // Adjust property names to match Entities.Concrete.Employee
    public class EmployeeModel  
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public int DepartmentId { get; set; }
    }
}