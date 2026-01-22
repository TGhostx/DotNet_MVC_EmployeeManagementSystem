using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.Application.Interfaces.Repositories;
using EMS.Domain.Models;
using EMS.Infrastructure.Data;

namespace EMS.Infrastructure.Repositories
{
    public class JobRepository : GenericRepository<Job>, IJobRepository
    {
        public JobRepository(EmsDbContext context) : base(context) { }
    }
}