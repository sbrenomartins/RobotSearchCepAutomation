using Application.Services;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace API.DI;

public static class Startups
{
    public static IServiceCollection AddStartups(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IAddressRepository, AddressRepository>();
        services.AddScoped<IAddressService, AddressService>();
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlite("Data Source=robot.db");
        });

        return services;
    }
}
