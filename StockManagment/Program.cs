
using StockManagment.Application.contract;
using StockManagment.Application.Services;
using StockManagment.Infrastructure;

namespace StockManagment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddInfrastructureServices(builder.Configuration);
            builder.Services.AddControllers();
            builder.Services.AddOpenApi();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
           

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            
            app.MapControllers();

            app.Run();
        }
    }
}
