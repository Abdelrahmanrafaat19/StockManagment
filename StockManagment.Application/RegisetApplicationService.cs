using Microsoft.Extensions.DependencyInjection;
using StockManagment.Application.contract;
using StockManagment.Application.Profiles;
using StockManagment.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagment.Application
{
    public static class RegisetApplicationService
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<IProductService , ProductService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IWareHouseService, WareHouseService>();
            services.AddAutoMapper(option => option.AddProfile(new WareHouseProfile()), typeof(RegisetApplicationService).Assembly);


            return services;
        }
    }
}
