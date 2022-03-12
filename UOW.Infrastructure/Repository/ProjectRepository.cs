using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UOW.Core.Entities;
using UOW.Core.Interfaces;

namespace UOW.Infrastructure.Repository
{
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        public ProjectRepository(PMSDbContext context, ILogger logger) : base(context, logger)
        {
        }
    }
}
