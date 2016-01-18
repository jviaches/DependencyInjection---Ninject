using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionNInject1
{
    class Program
    {
        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            IConfirmationMessageSender confirmationMessage = kernel.Get<IConfirmationMessageSender>();
            MessageSender messageSender = new MessageSender(confirmationMessage);
            messageSender.SendMessage("Some text", "123456789");

            Console.ReadKey();
        }
    }

    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IConfirmationMessageSender>().To<EmailMessageSender>();
        }
    }
}
