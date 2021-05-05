using DI.App.Abstractions;
using DI.App.Services;
using DI.App.Services.PL;
using DI.App.Services.PL.Commands;
using System.Collections.Generic;

namespace DI.App
{
    internal class Program
    {
        private static void Main()
        {
            var userStore = new UserStore();

            var add = new AddUserCommand(userStore);
            var listuser = new ListUsersCommand(userStore);
            List<ICommand> list = new List<ICommand>();
            list.Add(add);
            list.Add(listuser);
            // Inversion of Control
            var processor = new CommandProcessor(list);
            var manager = new CommandManager(processor);

            manager.Start();
        }
    }
}
