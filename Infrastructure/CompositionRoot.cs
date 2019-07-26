using Castle.MicroKernel.Registration;
using Castle.Windsor;
using RegulatoryNewsService;
using RegulatoryNewsService.Configurations;

namespace Infrastructure
{
    public class CompositionRoot
    {
        private readonly WindsorContainer _container;

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
                Component.For<IAppConfiguration>().ImplementedBy<AppConfiguration>(),
                Component.For<IUrlLinkProvider>().ImplementedBy<RnsSearchResultsUrlLinkProvider>(),
                Component.For<ILinkDownloader>().ImplementedBy<LinkDownloader>(),
                Component.For<IArrayExtractor>().ImplementedBy<ArrayExtractor>(),
                Component.For<ICompanyNewsSearcher>().ImplementedBy<CompanyNewsSearcher>()

            );

        }

        public ICompanyNewsSearcher Get()
        {
            return _container.Resolve<ICompanyNewsSearcher>();
        }
    }
}
