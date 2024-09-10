using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EFCore;
using Services;
using Services.Contracts;

namespace TrainReservationAPI.Extensions
{
    public static class ServicesExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services,
               IConfiguration configuration) => services.AddDbContext<RepositoryContext>(opts =>
                   opts.UseSqlServer(configuration.GetConnectionString("sqlConnection")));

        public static void ConfigureRepositoryManager(this IServiceCollection services)
        {
            services.AddScoped<ITrainRepository, TrainRepository>(); // Train repository
            services.AddScoped<IWagonRepository, WagonRepository>(); // Wagon repository
            services.AddScoped<IRepositoryManager, RepositoryManager>(); // Repository manager
        }

        public static void ConfigureServiceManager(this IServiceCollection services) 
        {
            services.AddScoped<IServiceManager, ServiceManager>(); // Service manager
            services.AddScoped<ITrainService, TrainManager>(); // Train service
            services.AddScoped<IWagonService, WagonManager>(); // Wagon service
        }
            

        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddSingleton<ILoggerService, LoggerManager>();
    }
}
