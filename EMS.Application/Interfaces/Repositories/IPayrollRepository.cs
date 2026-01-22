using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.Domain.Models;

namespace EMS.Application.Interfaces.Repositories
{
    public interface IPayrollRepository: IGenericRepository<Payroll>
    {
        Task<Payroll?> GetByPeriodAsync(int employeeId, int month, int year);
    }
}