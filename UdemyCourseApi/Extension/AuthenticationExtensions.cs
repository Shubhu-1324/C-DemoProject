﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace UdemyCourseApi.Extension
{
    public static class AuthenticationExtensions
    {
        public static IServiceCollection AutheticationCollection(this IServiceCollection services, IConfiguration configuration )
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => options.TokenValidationParameters=new TokenValidationParameters
            {
                ValidateIssuer=true,
                ValidateAudience=true,
                ValidateLifetime=true,
                ValidateIssuerSigningKey=true,
                ValidIssuer=configuration["Jwt:Issuer"],
                ValidAudience=configuration["Jwt:Audience"],
                IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))

            });
            return services;
        }
    }
}
