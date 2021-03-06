using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace FileManager.Infrastructure
{
    public static class DIExtension
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FileDbContext>(c =>
                //todo 
                //add logic to determine which database to use

                //c.UseNpgsql(Configuration.GetConnectionString("PostgresConnection"))
                c.UseSqlServer(configuration.GetConnectionString("SqlServerConnection"))
            );
            return services;
        }
    }
}
