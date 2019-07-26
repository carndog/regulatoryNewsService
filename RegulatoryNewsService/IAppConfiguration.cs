using RegulatoryNewsService.Configurations;

namespace RegulatoryNewsService
{
    public interface IAppConfiguration
    {
        SymbolsConfiguration SymbolsConfiguration { get; }

        SearchConfiguration SearchConfiguration { get; }

        UrlsConfiguration UrlsConfiguration { get; }

        MetaDataConfiguration MetaDataConfiguration { get; }
    }
}