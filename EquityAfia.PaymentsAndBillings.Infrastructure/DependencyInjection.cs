using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using EquityAfia.PaymentsAndBillings.Infrastructure.Data;
using EquityAfia.PaymentsAndBillings.Infrastructure.Repositories;
using EquityAfia.PaymentsAndBillings.Application.Interfaces;
using EquityAfia.PaymentsAndBillings.Application.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // Register DbContext
        services.AddDbContext<EquityAfiaDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        // Register repositories
        services.AddScoped<IBillingRepository, BillingRepository>();

        // Register services
        services.AddScoped<IBillingService, BillingService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IEPharmacyService, EPharmacyService>();
        services.AddScoped<IAppointmentService, AppointmentService>();

        return services;
    }
}
