using MSN.Domain.Interfaces;
using MSN.Domain.Models.Processes;
using MSN.Infrastructure.Persistence;
using MSN.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MSN.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<MSNDbContext>(options =>
                options.UseNpgsql(config.GetConnectionString("DefaultConnection")));

            services.AddScoped<IProcessRepository, ProcessRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

        public static async Task ApplyMigrationsAndSeedAsync(this IHost app)
        {
            using var scope = app.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<MSNDbContext>();

            db.Database.Migrate();
            await DatabaseSeeder.SeedAsync(scope.ServiceProvider);
        }
    }
}