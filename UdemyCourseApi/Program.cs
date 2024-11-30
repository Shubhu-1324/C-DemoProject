
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




            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.Configureswagger();
            builder.Services.AddCustomDatabaseContexts(builder.Configuration);
            builder.Services.RepositoryCollection();
            builder.Services.AutomapperCollection();
            builder.Services.IdentityCollection();

           
            builder.Services.AutheticationCollection(builder.Configuration);
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseStaticFiles();
            app.MapControllers();

            app.Run();
        }
    }
}
