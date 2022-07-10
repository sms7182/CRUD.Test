using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Data.Configuration
{
    public static class DBConfiguration
    {
        public static IServiceCollection AddDataBaseConfiguration(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddEntityFrameworkNpgsql().AddDbContext<CarDbContext>(options =>
            {
                options.UseNpgsql(configuration["carDBConnection"], d => d.MigrationsAssembly(typeof(CarDbContext).Assembly.GetName().Name));
            });

            return services;

        }
    }
}
