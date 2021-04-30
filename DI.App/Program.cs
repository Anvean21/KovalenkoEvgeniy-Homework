using DI.App.Abstractions;
using DI.App.Services;
using DI.App.Services.PL;
using DI.App.Services.PL.Commands;

namespace DI.App
{
    internal class Program
    {
        private static void Main()
        {
            var userStore1 = new UserStore();
            var userStore2 = new UserStore();

            var add = new AddUserCommand(userStore1);
            var list = new AddUserCommand(userStore2);
            // Inversion of Control
            var processor = new CommandProcessor(add, list);
            var manager = new CommandManager(processor);

            manager.Start();
        }
    }
}
