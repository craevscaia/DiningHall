using DiningHall.DiningHall;
using DiningHall.Repository.FoodRepository;
using DiningHall.Repository.OrderRepository;
using DiningHall.Repository.TableRepository;
using DiningHall.Repository.WaiterRepsoitory;
using DiningHall.Services.FoodService;
using DiningHall.Services.OrderService;
using DiningHall.Services.RegisterRestaurantService;
using DiningHall.Services.TableService;
using DiningHall.Services.WaiterService;

namespace DiningHall;

public class Startup
{
    private IConfiguration ConfigRoot { get; }

    public Startup(IConfiguration configuration)
    {
        ConfigRoot = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddRazorPages();
        services.AddSingleton<IFoodRepository, FoodRepository>();
        services.AddSingleton<ITableRepository, TableRepository>();
        services.AddSingleton<IWaiterRepository, WaiterRepository>();
        services.AddSingleton<IOrderRepository, OrderRepository>();
        
        services.AddSingleton<IOrderService, OrderService>();
        services.AddSingleton<ITableService, TableService>();
        services.AddSingleton<IWaiterService, WaiterService>();
        services.AddSingleton<IFoodService, FoodService>();
        services.AddSingleton<IRegisterRestaurantService, RegisterRestaurantService>();
        
        services.AddSingleton<IDiningHall, DiningHall.DiningHall>();
        services.AddHostedService<BackgroundTask.BackgroundTask>();
    }

    public static void Configure(WebApplication app, IWebHostEnvironment env)
    {
        // Configure the HTTP request pipeline.
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}