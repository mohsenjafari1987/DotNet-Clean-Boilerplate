using MSN.Application;
using MSN.Infrastructure;

namespace MSN.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services
                .AddApplication()
                .AddInfrastructure(builder.Configuration)
                .AddAuthorization()
                .AddEndpointsApiExplorer()
                .AddSwaggerGen(options =>
                    {
                        options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                        {
                            Title = "Your API",
                            Version = "v1"
                        });
                    });

            builder.Services.AddScoped<ExceptionMiddleware>();

            var app = builder.Build();

            await app.ApplyMigrationsAndSeedAsync();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API V1");
                    options.RoutePrefix = "swagger"; // default
                });
            }

            app.UseHttpsRedirection();

            app.UseMiddleware<ExceptionMiddleware>();
            app.UseAuthorization();

            app.MapGet("/", () => "API is running ✅");

            await app.RunAsync();
        }
    }
}
