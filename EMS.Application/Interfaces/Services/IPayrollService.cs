using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.Application.DTOs.Payroll;

namespace EMS.Application.Interfaces.Services
{
    public interface IPayrollService
    {
        Task GenerateAsync(GeneratePayrollDto dto);
    }
}