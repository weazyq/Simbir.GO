using Domain.Services;
using EF.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Services.Accounts;
using Services.Accounts.Repositories;
using Services.Payments;
using Services.Payments.Repositorie;
using Services.Payments.Repositories;
using Services.Transports;
using Services.Transports.Repositories;

namespace Services.Configurator;

public static class ServicesConfigurator
{
    public static void Initialize(this IServiceCollection services)
    {
        services.AddScoped<IDbRepository, DbRepository>();

        #region Accounts

        services.AddTransient<IAccountService, AccountService>();
        services.AddTransient<IAccountRepository, AccountRepository>();

        #endregion

        #region Transports

        services.AddTransient<ITransportService, TransportService>();
        services.AddTransient<ITransportRepository, TransportRepository>();

        #endregion

        #region Payment

        services.AddTransient<IPaymentService, PaymentService>();
        services.AddTransient<IPaymentRepository, PaymentRepository>();

        #endregion
    }
}