namespace FromTest;

public sealed class BranchDto { public int Id { get; set; } public string Name { get; set; } = ""; public string? Address { get; set; } public DateTime? CreateDate { get; set; } public DateTime? UpdateDate { get; set; } }
public sealed class DepartmentDto { public int Id { get; set; } public string Name { get; set; } = ""; public int BranchId { get; set; } public string? BranchName { get; set; } public DateTime? CreateDate { get; set; } public DateTime? UpdateDate { get; set; } }
public sealed class PositionDto { public int Id { get; set; } public string Name { get; set; } = ""; public int DepartmentId { get; set; } public string? DepartmentName { get; set; } public int BranchId { get; set; } public string? BranchName { get; set; } }
public sealed class EmployeeDto { public int Id { get; set; } public string FirstName { get; set; } = ""; public string LastName { get; set; } = ""; public int BranchId { get; set; } public int DepartmentId { get; set; } public int PositionId { get; set; } public DateTime? HireDate { get; set; } public DateTime? TerminationDate { get; set; } public bool IsActive { get; set; } }
public sealed class AssignmentDto { public int Id { get; set; } public int EmployeeId { get; set; } public int PositionId { get; set; } public DateTime AssignedAt { get; set; } public DateTime? EndedAt { get; set; } }

public sealed class Result { public bool Success { get; set; } public string? Message { get; set; } }
public sealed class DataResult<T> { public bool Success { get; set; } public string? Message { get; set; } public T? Data { get; set; } }
