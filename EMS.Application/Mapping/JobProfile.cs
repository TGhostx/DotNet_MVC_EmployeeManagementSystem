using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EMS.Application.DTOs.Job;
using EMS.Domain.Models;

namespace EMS.Application.Mapping
{
    public class JobProfile: Profile
    {
        public JobProfile()
        {
            CreateMap<Job, JobDto>();
            CreateMap<CreateJobDto, Job>().ConstructUsing(dto => new Job(dto.Title, dto.BaseSalary));
        }
    }
}