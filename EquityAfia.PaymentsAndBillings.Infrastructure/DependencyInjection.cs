using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using EquityAfia.PaymentsAndBillings.Infrastructure.Data;
using EquityAfia.PaymentsAndBillings.Application.Interfaces;
using EquityAfia.PaymentsAndBillings.Application.Services;
using EquityAfia.PaymentsAndBillings.Application.Interfaces.Billing;
using EquityAfia.PaymentsAndBillings.Application.Services.BillingService;
using EquityAfia.PaymentsAndBillings.Application.Services.PaymentService;
using EquityAfia.PaymentsAndBillings.Application.Services.PaymentService.StripeService;
using EquityAfia.PaymentsAndBillings.Application.Interfaces.Payments.Stk;
using EquityAfia.PaymentsAndBillings.Application.Services.PaymentService.StkFolder;
using EquityAfia.PaymentsAndBillings.Infrastructure.Repositories;
using EquityAfia.PaymentsAndBillings.Application.Repositories;
using Mapster;
using MapsterMapper;
using Microsoft.Win32;

namespace EquityAfia.PaymentsAndBillings.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Register DbContext
            _ = services.AddDbContext<EquityAfiaDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Register repositories
            _ = services.AddScoped<IBillingRepository, BillingRepository>();

            // Register services
            _ = services.AddScoped<IBillingService, BillingService>();
            _ = services.AddScoped<IUserService, UserService>();
            _ = services.AddScoped<IEPharmacyService, EPharmacyService>();
            _ = services.AddScoped<IAppointmentService, AppointmentService>();
            _ = services.AddScoped<IPaymentService, PaymentService>();
            _ = services.AddScoped<IPaymentRepository, PaymentRepository>();
            _ = services.AddScoped<IStripeService, StripeService>();
            _ = services.AddScoped<IStkService, StkService>();
            _ = services.AddSingleton<IMapper, MapsterMapper>(); // Register MapsterMapper as IMapper

            // Register Mapster
            var config = TypeAdapterConfig.GlobalSettings;
            _ = config.Scan(typeof(DependencyInjection).Assembly);
            _ = services.AddSingleton(config);
            _ = services.AddScoped<IMapper, EquityAfia.PaymentsAndBillings.Infrastructure.Mapping.MapsterMapper>();

            return services;
        }
    }
}
