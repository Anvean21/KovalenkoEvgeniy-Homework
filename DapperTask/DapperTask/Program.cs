using DapperTask.BLL;
using DapperTask.DI;
using DapperTask.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace DapperTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var provider = Startup.ConfigureService();
            var service = provider.GetRequiredService<IHidingService>();
            service.GetByEmail("Email1");
        }
    }
}

