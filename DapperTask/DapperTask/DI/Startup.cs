using DapperTask.BLL;
using DapperTask.Core;
using DapperTask.DAL;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DapperTask.DI
{
    public class Startup
    {
        public static IServiceProvider ConfigureService()
        {
            var provider = new ServiceCollection()
                .AddScoped(typeof(IRepository<>), typeof(DapperRepository<>))
                .AddScoped<IHidingService,HidingService>()
                .BuildServiceProvider(new ServiceProviderOptions());
            return provider;
        }
    }
}
