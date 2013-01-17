using System.Reflection;
using System.Web.Http;

using Castle.Windsor;
using Castle.Windsor.Installer;

namespace ArtificialGold.Infrastructure
{
    public class Bootstrapper
    {
        public static readonly IWindsorContainer Container = new WindsorContainer();

        public static void Init(Assembly applicationAssembly)
        {
            InitContainer(applicationAssembly);
            InitTasks();
        }

        private static void InitContainer(Assembly applicationAssembly)
        {
            Container.Install(FromAssembly.Instance(applicationAssembly));

            GlobalConfiguration.Configuration.DependencyResolver = new WindsorDependencyResolver(Container);
        }

        private static void InitTasks()
        {
            var bootstrapperTasks = Container.ResolveAll<IBootstrapperTask>();

            foreach (IBootstrapperTask bootstrapperTask in bootstrapperTasks)
            {
                bootstrapperTask.Execute();
            }
        }
    }
}