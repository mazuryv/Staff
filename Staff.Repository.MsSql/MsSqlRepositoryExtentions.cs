using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Staff.Repository.MsSql.Data;

namespace Staff.Repository.MsSql
{
    public static class MsSqlRepositoryExtentions
    {
        public static void AddMsSqlRepository(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddDbContext<StaffContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("StaffContext")));
        }
    }
}
