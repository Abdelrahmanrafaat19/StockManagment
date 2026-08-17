using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using StockManagment.Application.contract;
using StockManagment.Domain.Contracts;
using StockManagment.Infrastructure.Data;
using StockManagment.Infrastructure.IdentityData;
using StockManagment.Infrastructure.Repostory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagment.Infrastructure
{
    public static class InfrastructuresRegisterService
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services , IConfiguration configuration)
        {
            services.AddDbContext<StockManagmentDb>(option => option.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<UsersDbContext>(option => option.UseSqlServer(configuration.GetConnectionString("IdentityConnection")));
            services.AddScoped<IUniteOfWork , UniteOfWork>();
            services.AddIdentityCore<ApplictionUser>()
              .AddRoles<IdentityRole>()
              .AddEntityFrameworkStores<UsersDbContext>();
            services.AddScoped<IJwtTokenCreator,JwtTokenCreator>();
            services.AddScoped<IIdentityService, IdentityService>();
            var jwtSettings = configuration
                                             .GetSection("JwtSettings")
                                             .Get<JwtSettings>()
                                             ?? throw new InvalidOperationException("JWT Settings are missing.");
            services
            .AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = jwtSettings.Issuer,

                    ValidateAudience = true,
                    ValidAudience = jwtSettings.Audience,

                    ValidateLifetime = true,

                    ValidateIssuerSigningKey = true,

                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtSettings.Key)),

                    ClockSkew = TimeSpan.Zero
                };
            });
            return services;
        }
    }
}
