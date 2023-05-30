using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Aplication.Interfaces;

namespace TestTask.Persistance
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<TestTaskDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddScoped<ITestTaskDbContext>(provider =>
                provider.GetService<TestTaskDbContext>());

            return services;

        }
    }
}
