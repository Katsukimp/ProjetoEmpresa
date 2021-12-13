using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace HiringTest.Infrastructure.ExtensionMethods
{
    public static class CommonInjectDependence
    {
        public static void AddFormat()
        {
            var cultureInfo = new CultureInfo("en-US");
            cultureInfo.NumberFormat.NumberGroupSeparator = ",";

            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
        }
        public static IServiceCollection AddServices(this IServiceCollection services)
        {

            services.AddTransient<HiringTest.Interface.IPersonViewModelService, HiringTest.Services.PersonViewModelService>();
            services.AddTransient<HiringTest.Interface.IBankViewModelService, HiringTest.Services.BankViewModelService>();
            services.AddTransient<HiringTest.Interface.IAccountViewModelService, HiringTest.Services.AccountViewModelService>();
            services.AddTransient<HiringTest.Interface.ILogAccountViewModelService, HiringTest.Services.LogAccountViewModelService>();

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<HiringTest.Domain.Interfaces.IPersonRepository, HiringTest.Infrastructure.Data.Repositories.PersonRepository>();
            services.AddTransient<HiringTest.Domain.Interfaces.IBankRepository, HiringTest.Infrastructure.Data.Repositories.BankRepository>();
            services.AddTransient<HiringTest.Domain.Interfaces.IAccountRepository, HiringTest.Infrastructure.Data.Repositories.AccountRepository>();
            services.AddTransient<HiringTest.Domain.Interfaces.ILogAccountRepository, HiringTest.Infrastructure.Data.Repositories.LogAccountRepository>();

            return services;
        }
    }
}
