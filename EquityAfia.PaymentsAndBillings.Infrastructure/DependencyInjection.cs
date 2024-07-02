using EquityAfia.PaymentsAndBillings.Application.Interfaces.Billing;
using EquityAfia.PaymentsAndBillings.Application.Interfaces.Payments.Stk;
using EquityAfia.PaymentsAndBillings.Application.Interfaces;
using EquityAfia.PaymentsAndBillings.Application.Repositories;
using EquityAfia.PaymentsAndBillings.Application.Services.BillingService;
using EquityAfia.PaymentsAndBillings.Application.Services.PaymentService.StkFolder;
using EquityAfia.PaymentsAndBillings.Application.Services.PaymentService.StripeService;
using EquityAfia.PaymentsAndBillings.Application.Services.PaymentService;
using EquityAfia.PaymentsAndBillings.Application.Services;
using EquityAfia.PaymentsAndBillings.Contracts.Messages.AppointmentBookings;
using EquityAfia.PaymentsAndBillings.Infrastructure.Data;
using EquityAfia.PaymentsAndBillings.Infrastructure.Mapping;
using EquityAfia.PaymentsAndBillings.Infrastructure.Repositories;
using Mapster;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace EquityAfia.PaymentsAndBillings.Infrastructure
{
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
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IStripeService, StripeService>();
            services.AddScoped<IStkService, StkService>();

            // Register Mapster
            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(typeof(DependencyInjection).Assembly);
            services.AddSingleton(config);
            services.AddScoped<Mapping.IMapper, MapsterMapperImpl>();

            // Register MassTransit
            services.AddMassTransit(x =>
            {
                x.AddRequestClient<GetUserDetailsRequest>();
                x.AddRequestClient<GetProductDetailsRequest>();
                x.AddRequestClient<GetAppointmentDetailsRequest>();

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(configuration["RabbitMQ:Host"], h =>
                    {
                        h.Username(configuration["RabbitMQ:Username"]);
                        h.Password(configuration["RabbitMQ:Password"]);
                    });
                });
            });

            services.AddMassTransitHostedService();

            return services;
        }
    }
}
