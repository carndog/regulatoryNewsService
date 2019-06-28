using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Microsoft.Extensions.Configuration;
using RegulatoryNewsService;

namespace Infrastructure
{
    public class CompositionRoot
    {
        private WindsorContainer _container;

        public CompositionRoot()
        {
            _container = new WindsorContainer();
        }

        public void Start()
        {
            _container.Register(Classes.FromAssemblyNamed("RegulatoryNewsService"));

            _container.Register(
                
                Component.For<IHttpClient>().ImplementedBy<HttpDownloadClient>(),
                Component.For<IFeedDownloader>().ImplementedBy<FeedDownloader>(),
                Component.For<IAppConfiguration>().ImplementedBy<AppConfiguration>()
            );

        }

        public IFeedDownloader Get()
        {
            return _container.Resolve<IFeedDownloader>();
        }
       
    }
}
