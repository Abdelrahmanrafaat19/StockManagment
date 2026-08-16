using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
            services.AddScoped<IJwtTokenCreator,JwtTokenCreator>();
           
            return services;
        }
    }
}
