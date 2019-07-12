namespace RegulatoryNewsService
{
    public interface IAppConfiguration
    {
        SymbolsConfiguration SymbolsConfiguration { get; }

        UrlsConfiguration UrlsConfiguration { get; }

        MetaDataConfiguration MetaDataConfiguration { get; }
    }
}