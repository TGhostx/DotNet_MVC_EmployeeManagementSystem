using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EMS.Application.DTOs.Payroll;
using EMS.Domain.Models;

namespace EMS.Application.Mapping
{
    public class PayrollProfile: Profile
    {
        public PayrollProfile()
        {
            CreateMap<Payroll, PayrollDto>();
        }
    }
}