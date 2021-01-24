using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TicketSystem.API.DBConnector
{
    public static class DBServiceExtension
    {
        public static IServiceCollection SetUpDatabase<T>(this IServiceCollection services, IConfiguration configuration) where T : DbContext
        {
            DataBaseOptions dataBaseOptions = new DataBaseOptions();
            configuration.Bind(DataBaseOptions.DataBase, dataBaseOptions);
            services.AddSingleton(dataBaseOptions);

            services.AddDbContext<T>(optionsBuilder => {
                if (!optionsBuilder.IsConfigured && !string.IsNullOrWhiteSpace(dataBaseOptions.ConnectionString))
                {
                    optionsBuilder.UseSqlServer(dataBaseOptions.ConnectionString);
                }
            });

            return services;
        }
    }
}
