using Business.Abstract;
using Business.Concrete;
using Business.ValidationRules.FluentValidation;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using FluentValidation;
using Entities.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IDepartmentDal, EfDepartmenDal>();
builder.Services.AddScoped<IDepartmentService, DepartmentManager>();

builder.Services.AddScoped<IBranchService, BranchManager>();
builder.Services.AddScoped<IBranchDal, EfBranchDal>();

builder.Services.AddScoped<IEmployeeDal, EfEmployeeDal>();
builder.Services.AddScoped<IEmployeeService, EmployeeManager>();

builder.Services.AddScoped<IEmployeeAssignmentDal, EfEmployeeAssignmentDal>();
builder.Services.AddScoped<IEmployeeAssignmentService, EmployeeAssignmentManager>();

builder.Services.AddScoped<IPositionDal, EfPositionDal>();
builder.Services.AddScoped<IPositionService, PositionManager>();

// FluentValidation registrations
builder.Services.AddScoped<IValidator<Employee>, EmployeeValidator>();
builder.Services.AddScoped<IValidator<Branch>, BranchValidator>();
builder.Services.AddScoped<IValidator<Department>, DepartmentValidator>();
builder.Services.AddScoped<IValidator<Position>, PositionValidator>();
builder.Services.AddScoped<IValidator<EmployeeAssignment>, EmployeeAssignmentValidator>();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();




