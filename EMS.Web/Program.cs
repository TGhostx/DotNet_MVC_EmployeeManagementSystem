using EMS.Application;
using EMS.Application.Interfaces.Repositories;
using EMS.Application.Interfaces.Services;
using EMS.Application.Mapping;
using EMS.Application.Services;
using EMS.Infrastructure.Data;
using EMS.Infrastructure.Repositories;
using EMS.Application.Interfaces;
using EMS.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<EmsDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("EmsDbConnection")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
// Scope Repository
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IJobRepository, JobRepository>();
builder.Services.AddScoped<IAttendanceRepository, AttendanceRepository>();
builder.Services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
builder.Services.AddScoped<IPayrollRepository, PayrollRepository>();
// Scope Services
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IJobService, JobService>();
builder.Services.AddScoped<IAttendanceService, AttendanceService>();
builder.Services.AddScoped<ILeaveRequestService, LeaveRequestService>();
builder.Services.AddScoped<IPayrollService, PayrollService>();
// Mappers
builder.Services.AddAutoMapper(typeof(EmployeeProfile).Assembly);
// builder.Services.AddAutoMapper(typeof(DepartmentProfile).Assembly);
// builder.Services.AddAutoMapper(typeof(JobProfile).Assembly);
// builder.Services.AddAutoMapper(typeof(LeaveRequestProfile).Assembly);
// builder.Services.AddAutoMapper(typeof(AttendanceProfile).Assembly);
// builder.Services.AddAutoMapper(typeof(PayrollProfile).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
