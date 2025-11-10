using Microsoft.EntityFrameworkCore;
using ProvaTecnica.Context;

namespace ProvaTecnica.Dependencies
{
    public static class Dependencies
    {
        public static void InjecaoDeDependencias(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DBContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DBProvaTecnica"));
            });


        }
    }
}
