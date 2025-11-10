using Microsoft.EntityFrameworkCore;
using ProvaTecnica.Context;
using ProvaTecnica.Repositories.Interfaces;
using ProvaTecnica.Repositories.Repository;
using ProvaTecnica.Services.Interfaces;
using ProvaTecnica.Services.Services;

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


            #region //Services

            services.AddScoped<IAgendamentoServices, AgendamentoServices>();
            services.AddScoped<ISalaServices, SalaServices>();

            #endregion


            #region //Repositories

            services.AddScoped<IAgendamentoRepository, AgendamentoRepository>();
            services.AddScoped<ISalaRepository, SalaRepository>();

            #endregion

        }
    }
}
