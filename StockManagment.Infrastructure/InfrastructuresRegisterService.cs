using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StockManagment.Domain.Contracts;
using StockManagment.Infrastructure.Data;
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
            services.AddScoped<IUniteOfWork , UniteOfWork>();
           
            return services;
        }
    }
}
