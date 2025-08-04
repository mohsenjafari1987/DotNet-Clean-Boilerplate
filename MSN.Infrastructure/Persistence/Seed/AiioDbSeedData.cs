using System.Collections.Concurrent;
using MSN.Domain.Models.Departments;
using MSN.Domain.Models.Locations;
using MSN.Domain.Models.Processes;
using MSN.Domain.Models.Resources;
using MSN.Domain.Models.Roles;
using MSN.Domain.Models.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MSN.Infrastructure.Persistence
{
    public static class DatabaseSeeder
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<MSNDbContext>();

            try
            {
                // Ensure the database is created
                await context.Database.EnsureCreatedAsync();

                var userCount = await context.Users.CountAsync();
                // Seed Users
                if (userCount < 1000)
                {
                    var users = new ConcurrentBag<User>();

                    Parallel.For(1, 1001 - userCount, i =>
                    {
                        var newUser = User.Create(userCount + i, $"User {userCount + i}");
                        users.Add(newUser);
                    });
                    // Add users to the context
                    await context.Users.AddRangeAsync(users);
                    await context.SaveChangesAsync();
                }

                var user = await context.Users.FirstAsync();

                // Seed Locations
                var locationCount = await context.Locations.CountAsync();
                if (locationCount < 1000)
                {
                    var locations = new ConcurrentBag<Location>();

                    Parallel.For(1, 1001 - locationCount, i =>
                    {
                        var newLocation = Location.Create(locationCount + i, $"Location {locationCount + i}", user);
                        locations.Add(newLocation);
                    });
                    // Add locations to the context
                    await context.Locations.AddRangeAsync(locations);
                    await context.SaveChangesAsync();
                }

                // Seed Roles
                var roleCount = await context.Roles.CountAsync();
                if (roleCount < 1000)
                {
                    var roles = new ConcurrentBag<Role>();
                    Parallel.For(1, 1001 - roleCount, i =>
                    {
                        var newRole = Role.Create(roleCount + i, $"Role {roleCount + i}", user);
                        roles.Add(newRole);
                        
                    });
                    // Add roles to the context
                    await context.Roles.AddRangeAsync(roles);
                    await context.SaveChangesAsync();
                }

                // Seed Resources
                var resourceCount = await context.Resources.CountAsync();
                if (resourceCount<1000)
                {
                    var resources = new ConcurrentBag<Resource>();
                    Parallel.For(1, 1001 - resourceCount, i =>
                    {
                        var newResource = Resource.Create(resourceCount + i, $"Resource {resourceCount + i}", user);
                        resources.Add(newResource);                        
                    });
                    // Add resources to the context
                    await context.Resources.AddRangeAsync(resources);
                    await context.SaveChangesAsync();
                }

                // Seed Departments
                var departmentCount = await context.Departments.CountAsync();
                if (departmentCount<1000)
                {
                    var departments = new ConcurrentBag<Department>();
                    Parallel.For(1, 1001 - departmentCount, i =>
                    {
                        var newDepartment = Department.Create(departmentCount + i, $"Department {departmentCount + i}", user);
                        departments.Add(newDepartment);                        
                    });
                    // Add departments to the context
                    await context.Departments.AddRangeAsync(departments);
                    await context.SaveChangesAsync();
                }

                // Seed Processes
                var processCount = await context.Processes.CountAsync();
                if (processCount < 1000)
                {
                    var department = await context.Departments.FirstAsync();
                    var role = await context.Roles.FirstAsync();
                    var resource = await context.Resources.FirstAsync();
                    var location = await context.Locations.FirstAsync();

                    var processes = new ConcurrentBag<Process>();
                    Parallel.For(1, 1001 - processCount, i =>
                    {
                        var newProcess = Process.Create(processCount + i, $"Process {processCount + i}", $"Description for Process {processCount + i}", user);
                        newProcess.AddDepartment(department);
                        newProcess.AddRole(role);
                        newProcess.AddResource(resource);
                        newProcess.AddLocation(location);

                        processes.Add(newProcess);                        
                    });

                    // Add processes to the context
                    await context.Processes.AddRangeAsync(processes);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while seeding the database.", ex);
            }
        }
    }
}
