using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.Application.DTOs.Payroll;
using EMS.Application.Interfaces;
using EMS.Application.Interfaces.Services;
using EMS.Domain.Models;

namespace EMS.Application.Services
{
    public class PayrollService : IPayrollService
    {
        private readonly IUnitOfWork _work;

        public PayrollService(IUnitOfWork work)
        {
            _work = work;
        }

        public async Task GenerateAsync(GeneratePayrollDto dto)
        {
            var employee = await _work.Employees.GetByIdAsync(dto.EmployeeId) ?? throw new KeyNotFoundException("Employee not found");

            var existingPayroll = await _work.Payrolls.GetByPeriodAsync(dto.EmployeeId, dto.Month, dto.Year);
            if (existingPayroll != null) throw new InvalidOperationException("Payroll already generated for this period");

            var payroll = new Payroll(dto.EmployeeId, dto.Month, dto.Year, employee.Job.BaseSalary);

            await _work.Payrolls.AddAsync(payroll);
            await _work.SaveChangesAsync();
        }
    }
}