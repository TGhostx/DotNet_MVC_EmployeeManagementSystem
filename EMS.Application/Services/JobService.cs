using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EMS.Application.DTOs.Job;
using EMS.Application.Interfaces;
using EMS.Application.Interfaces.Services;
using EMS.Domain.Models;

namespace EMS.Application.Services
{
    public class JobService : IJobService
    {
        private readonly IUnitOfWork _work;
        private readonly IMapper _mapper;

        public JobService(IUnitOfWork work, IMapper mapper)
        {
            _work = work;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<JobDto>> GetAllAsync()
        {
            var jobs = await _work.Jobs.GetAllAsync();

            return _mapper.Map<IReadOnlyList<JobDto>>(jobs);
        }
        public async Task<int> CreateAsync(CreateJobDto dto)
        {
            var job = _mapper.Map<Job>(dto);

            await _work.Jobs.AddAsync(job);
            await _work.SaveChangesAsync();

            return job.Id;
        }
    }
}