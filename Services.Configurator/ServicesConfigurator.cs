using Domain.Services;
using EF.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Services.Accounts;
using Services.Accounts.Repositories;

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
    }
}