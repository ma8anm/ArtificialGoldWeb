using ArtificialGold.Services.Phrases;

using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace ArtificialGold.Services
{
    public class WindsorInstaller:IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IHomeViewModelRetriever>().ImplementedBy<HomeViewModelRetriever>());
            container.Register(Component.For<IPhrasesRetriever>().ImplementedBy<PhrasesRetriever>());
        }
    }
}