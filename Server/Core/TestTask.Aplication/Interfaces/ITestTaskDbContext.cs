using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Domain;

namespace TestTask.Aplication.Interfaces
{
    public interface ITestTaskDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Organization> Organizations { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
