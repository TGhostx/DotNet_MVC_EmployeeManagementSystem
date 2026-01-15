using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EMS.Infrastructure.Data
{
    public class EmsDbContext: DbContext
    {
        public EmsDbContext(DbContextOptions<EmsDbContext> options) : base(options) { }

        // DbSets
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Department> Departments => Set<Department>();
        public DbSet<Job> Jobs => Set<Job>();
        public DbSet<Attendance> Attendances => Set<Attendance>();
        public DbSet<LeaveRequest> LeaveRequests => Set<LeaveRequest>();
        public DbSet<Payroll> Payrolls => Set<Payroll>();


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Employee <=> Department (Many-to-One)
            builder.Entity<Employee>().HasOne(e => e.Department).WithMany(d => d.Employees).HasForeignKey(e => e.DepartmentId).OnDelete(DeleteBehavior.Restrict);

            // Employee <=> Job (Many-to-One)
            builder.Entity<Employee>().HasOne(e => e.Job).WithMany(j => j.Employees).HasForeignKey(e => e.JobId).OnDelete(DeleteBehavior.Restrict);

            // Employee <=> Attendance (One-to-Many)
            builder.Entity<Attendance>().HasOne(a => a.Employee).WithMany(e => e.Attendances).HasForeignKey(a => a.EmployeeId).OnDelete(DeleteBehavior.Cascade);

            // Employee <=> LeaveRequest (One-to-Many)
            builder.Entity<LeaveRequest>().HasOne(l => l.Employee).WithMany(e => e.LeaveRequests).HasForeignKey(l => l.EmployeeId).OnDelete(DeleteBehavior.Cascade);

            // Employee <=> Payroll (One-to-Many)
            builder.Entity<Payroll>().HasOne(p => p.Employee).WithMany(e => e.Payrolls).HasForeignKey(p => p.EmployeeId).OnDelete(DeleteBehavior.Cascade);

            // Payroll unique constraint (Employee + Month + Year)
            builder.Entity<Payroll>().HasIndex(p => new { p.EmployeeId, p.Month, p.Year }).IsUnique();
        }
    }
}