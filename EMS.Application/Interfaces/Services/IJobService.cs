using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.Application.DTOs.Job;

namespace EMS.Application.Interfaces.Services
{
    public interface IJobService
    {
        Task<IReadOnlyList<JobDto>> GetAllAsync();
        Task<int> CreateAsync(CreateJobDto dto);
    }
}