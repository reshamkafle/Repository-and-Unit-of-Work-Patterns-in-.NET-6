using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UOW.Core.Interfaces;
using UOW.Infrastructure.Repository;

namespace UOW.Infrastructure.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PMSDbContext _context;
        private readonly ILogger _logger;
        public IProjectRepository Projects { get; private set; }

        public UnitOfWork(
            PMSDbContext context,
            ILoggerFactory logger
            )
        {
            _context = context;
            _logger = logger.CreateLogger("logs");

            Projects = new ProjectRepository(_context, _logger);
        }

        public async Task<int> CompletedAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
