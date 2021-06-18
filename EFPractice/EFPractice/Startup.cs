using EFPractice.BLL.Services;
using EFPractice.Core.Interfaces;
using EFPractice.Core.Services;
using EFPractice.DAL;
using EFPractice.DAL.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFPractice
{
    public class Startup
    {
        public static IServiceProvider ConfigureService()
        {
            var provider = new ServiceCollection()
                .AddScoped(typeof(IRepository<>), typeof(EFRepository<>))
                .AddScoped<FileContext>()
                .AddTransient<IFileService,FileService>()
                .AddTransient<IDirectoryService,DirectoryService>()
                .BuildServiceProvider();

            return provider;
        }
    }
}
