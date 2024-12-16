using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using UdemyCourseApi.Data;
using UdemyCourseApi.Mappings;
using UdemyCourseApi.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Identity;
using UdemyCourseApi.Extension;

namespace UdemyCourseApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder = WebApplication.CreateBuilder(new WebApplicationOptions
            {
                // Set the WebRootPath before building the application
                WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")
            });

            // Add services to the container.
            builder.Services.AddControllers();

            // CORS policy configuration
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins", policy =>
                {
                    policy.AllowAnyOrigin()       // Allow all origins (or replace with specific URL for security)
                        .AllowAnyMethod()        // Allow any HTTP method (GET, POST, etc.)
                        .AllowAnyHeader();       // Allow any headers
                });
            });

            // Configure Swagger
            builder.Services.Configureswagger();

            // Add database contexts
            builder.Services.AddCustomDatabaseContexts(builder.Configuration);

            // Add repositories and automapper
            builder.Services.RepositoryCollection();
            builder.Services.AutomapperCollection();

            // Add Identity services
            builder.Services.IdentityCollection();

            // Authentication setup
            builder.Services.AutheticationCollection(builder.Configuration);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Use HTTPS redirection
            app.UseHttpsRedirection();

            // Enable authentication and authorization
            app.UseAuthentication();
            app.UseAuthorization();

            // Enable static file serving
            app.UseStaticFiles();

            // Use the CORS policy
            app.UseCors("AllowAllOrigins");

            // Map controllers
            app.MapControllers();

            // Run the application
            app.Run();
        }
    }
}
