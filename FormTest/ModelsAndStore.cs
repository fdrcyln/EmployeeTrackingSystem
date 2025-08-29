using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace FormTest
{
    // DTOs
    public class BranchDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Address { get; set; } = "";
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime UpdateDate { get; set; } = DateTime.Now;
    }

    public class DepartmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int BranchId { get; set; }
        public string BranchName { get; set; } = "";
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime UpdateDate { get; set; } = DateTime.Now;
    }

    public class PositionDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; } = "";
        public int BranchId { get; set; }
        public string BranchName { get; set; } = "";
    }

    public class EmployeeDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public int BranchId { get; set; }
        public int DepartmentId { get; set; }
        public int PositionId { get; set; }
        public string BranchName { get; set; } = "";
        public string DepartmentName { get; set; } = "";
        public string PositionName { get; set; } = "";
        public DateTime HireDate { get; set; } = DateTime.Now;
        public DateTime? TerminationDate { get; set; }
        public bool IsActive { get; set; } = true;
        public string FullName => $"{FirstName} {LastName}";
    }

    public class AssignmentDto
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int PositionId { get; set; }
        public string EmployeeName { get; set; } = "";
        public string PositionName { get; set; } = "";
        public DateTime AssignedAt { get; set; } = DateTime.Now;
        public DateTime? EndedAt { get; set; }
    }

    // In-Memory Store
    public class InMemoryStore
    {
        private int _nextBranchId = 1;
        private int _nextDepartmentId = 1;
        private int _nextPositionId = 1;
        private int _nextEmployeeId = 1;
        private int _nextAssignmentId = 1;

        public BindingList<BranchDto> Branches { get; private set; } = new();
        public BindingList<DepartmentDto> Departments { get; private set; } = new();
        public BindingList<PositionDto> Positions { get; private set; } = new();
        public BindingList<EmployeeDto> Employees { get; private set; } = new();
        public BindingList<AssignmentDto> Assignments { get; private set; } = new();

        public InMemoryStore()
        {
            InitializeSampleData();
            WireEvents();
        }

        private void InitializeSampleData()
        {
            // Sample Branches
            AddBranch("Ana Merkez", "Ýstanbul Merkez Mahallesi");
            AddBranch("Ankara Þubesi", "Ankara Kýzýlay");
            AddBranch("Ýzmir Þubesi", "Ýzmir Konak");

            // Sample Departments
            AddDepartment("Ýnsan Kaynaklarý", 1);
            AddDepartment("Bilgi Ýþlem", 1);
            AddDepartment("Muhasebe", 1);
            AddDepartment("Satýþ", 2);
            AddDepartment("Pazarlama", 3);

            // Sample Positions
            AddPosition("ÝK Uzmaný", 1);
            AddPosition("Yazýlým Geliþtirici", 2);
            AddPosition("Muhasebeci", 3);
            AddPosition("Satýþ Temsilcisi", 4);
            AddPosition("Pazarlama Uzmaný", 5);

            // Sample Employees
            AddEmployee("Ahmet", "Yýlmaz", 1, 1, 1, DateTime.Now.AddYears(-2));
            AddEmployee("Ayþe", "Kaya", 1, 2, 2, DateTime.Now.AddYears(-1));
            AddEmployee("Mehmet", "Demir", 2, 4, 4, DateTime.Now.AddMonths(-6));
        }

        private void WireEvents()
        {
            Branches.ListChanged += (s, e) => UpdateRelatedNames();
            Departments.ListChanged += (s, e) => UpdateRelatedNames();
            Positions.ListChanged += (s, e) => UpdateRelatedNames();
        }

        public void AddBranch(string name, string address)
        {
            Branches.Add(new BranchDto
            {
                Id = _nextBranchId++,
                Name = name,
                Address = address
            });
        }

        public void AddDepartment(string name, int branchId)
        {
            var branch = Branches.FirstOrDefault(b => b.Id == branchId);
            Departments.Add(new DepartmentDto
            {
                Id = _nextDepartmentId++,
                Name = name,
                BranchId = branchId,
                BranchName = branch?.Name ?? ""
            });
        }

        public void AddPosition(string name, int departmentId)
        {
            var department = Departments.FirstOrDefault(d => d.Id == departmentId);
            var branch = Branches.FirstOrDefault(b => b.Id == department?.BranchId);
            Positions.Add(new PositionDto
            {
                Id = _nextPositionId++,
                Name = name,
                DepartmentId = departmentId,
                DepartmentName = department?.Name ?? "",
                BranchId = department?.BranchId ?? 0,
                BranchName = branch?.Name ?? ""
            });
        }

        public void AddEmployee(string firstName, string lastName, int branchId, int departmentId, int positionId, DateTime hireDate)
        {
            var branch = Branches.FirstOrDefault(b => b.Id == branchId);
            var department = Departments.FirstOrDefault(d => d.Id == departmentId);
            var position = Positions.FirstOrDefault(p => p.Id == positionId);

            Employees.Add(new EmployeeDto
            {
                Id = _nextEmployeeId++,
                FirstName = firstName,
                LastName = lastName,
                BranchId = branchId,
                DepartmentId = departmentId,
                PositionId = positionId,
                BranchName = branch?.Name ?? "",
                DepartmentName = department?.Name ?? "",
                PositionName = position?.Name ?? "",
                HireDate = hireDate
            });
        }

        private void UpdateRelatedNames()
        {
            // Update Department branch names
            foreach (var dept in Departments)
            {
                var branch = Branches.FirstOrDefault(b => b.Id == dept.BranchId);
                dept.BranchName = branch?.Name ?? "";
            }

            // Update Position names
            foreach (var pos in Positions)
            {
                var dept = Departments.FirstOrDefault(d => d.Id == pos.DepartmentId);
                var branch = Branches.FirstOrDefault(b => b.Id == dept?.BranchId);
                pos.DepartmentName = dept?.Name ?? "";
                pos.BranchId = dept?.BranchId ?? 0;
                pos.BranchName = branch?.Name ?? "";
            }

            // Update Employee names
            foreach (var emp in Employees)
            {
                var branch = Branches.FirstOrDefault(b => b.Id == emp.BranchId);
                var dept = Departments.FirstOrDefault(d => d.Id == emp.DepartmentId);
                var pos = Positions.FirstOrDefault(p => p.Id == emp.PositionId);
                emp.BranchName = branch?.Name ?? "";
                emp.DepartmentName = dept?.Name ?? "";
                emp.PositionName = pos?.Name ?? "";
            }

            // Update Assignment names
            foreach (var assignment in Assignments)
            {
                var emp = Employees.FirstOrDefault(e => e.Id == assignment.EmployeeId);
                var pos = Positions.FirstOrDefault(p => p.Id == assignment.PositionId);
                assignment.EmployeeName = emp?.FullName ?? "";
                assignment.PositionName = pos?.Name ?? "";
            }
        }

        public IEnumerable<DepartmentDto> GetDepartmentsByBranch(int branchId)
        {
            return Departments.Where(d => d.BranchId == branchId);
        }

        public IEnumerable<PositionDto> GetPositionsByDepartment(int departmentId)
        {
            return Positions.Where(p => p.DepartmentId == departmentId);
        }

        public IEnumerable<EmployeeDto> FilterEmployees(string search = "", int branchId = 0, int departmentId = 0, int positionId = 0, bool? isActive = null)
        {
            var query = Employees.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.ToLower();
                query = query.Where(e => e.FirstName.ToLower().Contains(search) ||
                                       e.LastName.ToLower().Contains(search) ||
                                       e.FullName.ToLower().Contains(search));
            }

            if (branchId > 0)
                query = query.Where(e => e.BranchId == branchId);

            if (departmentId > 0)
                query = query.Where(e => e.DepartmentId == departmentId);

            if (positionId > 0)
                query = query.Where(e => e.PositionId == positionId);

            if (isActive.HasValue)
                query = query.Where(e => e.IsActive == isActive.Value);

            return query;
        }

        public void SaveToJson(string filePath)
        {
            try
            {
                var data = new
                {
                    Branches,
                    Departments,
                    Positions,
                    Employees,
                    Assignments
                };
                var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"JSON kaydetme hatasý: {ex.Message}", ex);
            }
        }

        public void LoadFromJson(string filePath)
        {
            try
            {
                if (!File.Exists(filePath)) return;

                var json = File.ReadAllText(filePath);
                var data = JsonSerializer.Deserialize<JsonElement>(json);

                // Clear existing data
                Branches.Clear();
                Departments.Clear();
                Positions.Clear();
                Employees.Clear();
                Assignments.Clear();

                // Load data
                if (data.TryGetProperty("Branches", out var branchesJson))
                {
                    var branches = JsonSerializer.Deserialize<List<BranchDto>>(branchesJson.GetRawText());
                    if (branches != null)
                    {
                        foreach (var branch in branches)
                            Branches.Add(branch);
                        _nextBranchId = Branches.Any() ? Branches.Max(b => b.Id) + 1 : 1;
                    }
                }

                // Similar logic for other collections...
                UpdateRelatedNames();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"JSON yükleme hatasý: {ex.Message}", ex);
            }
        }
    }
}