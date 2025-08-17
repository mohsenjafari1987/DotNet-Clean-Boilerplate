using Microsoft.Extensions.DependencyInjection;

namespace MSN.Infrastructure.Persistence
{
    public static class DatabaseSeeder
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<MSNDbContext>();

         
        }
    }
}
