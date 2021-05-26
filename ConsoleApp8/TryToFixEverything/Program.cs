using Autofac;
using BLL.Abstractions.Interfaces;
using BLL.Services;
using DAL.Abstractions.Interfaces;
using DAL.Services;
using System;

namespace ConsoleApp8
{
    // Task:
    // Program should return "Matching Record, got name=Fred, lastname=Smith, age=40"
    // Могут быть ошибки любого вида:
    // - отсутствие ссылок на проекты, классы, интерфейсы или же ссылки на несуществующие классы, методы, интерфейсы
    // - ошибки в нейминге
    // - ошибки в логике работы программы
    // - Ошибки в версии целевого фреймворка
    // - очепятки
    // - ошибки в DI контейнере
    // - и т.д.
    // Необходимо исправить все проблемы и ошибки системы и сделать так, чтобы программа заработала

    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<UserRepository>().As<IRepository>();

            using (var scope = builder.Build().BeginLifetimeScope())
            {
                var users = scope.Resolve<IUserService>().LoadRecords();

                foreach (var user in users)
                {
                    Console.WriteLine($"Matching Record, got name={user.FirstName}, lastname={user.LastName}, age={user.Age}");
                }
            }
            Console.ReadKey();
        }
    }
}