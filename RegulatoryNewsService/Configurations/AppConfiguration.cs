using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace RegulatoryNewsService.Configurations
{
    public class AppConfiguration : IAppConfiguration
    {
        private readonly IArrayExtractor _extractor;

        public AppConfiguration(IArrayExtractor extractor)
        {
            _extractor = extractor;
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json", false, true);

            IConfigurationRoot configurationRoot = configurationBuilder.Build();

            BuildSymbolsConfiguration(configurationRoot);
        }

        private void BuildSymbolsConfiguration(IConfigurationRoot configurationRoot)
        {
            IList<string> symbols = _extractor.ExtractValues("Symbols:Interest", configurationRoot);

            SymbolsConfiguration = new SymbolsConfiguration
            {
                Symbols = symbols.ToArray()
            };

            IList<string> phrases = _extractor.ExtractValues("Search:Phrases", configurationRoot);

            SearchConfiguration = new SearchConfiguration
            {
                Phrases = phrases.ToArray()
            };

            UrlsConfiguration = new UrlsConfiguration
            {
                BaseUrl = configurationRoot.GetSection("Urls:Base").Value,
                SearchUrl = configurationRoot.GetSection("Urls:Search").Value
            };

            MetaDataConfiguration = new MetaDataConfiguration
            {
                Extension = configurationRoot.GetSection("MetaData:Extension").Value
            };
        }

        public SymbolsConfiguration SymbolsConfiguration { get; private set; }

        public SearchConfiguration SearchConfiguration { get; private set; }

        public UrlsConfiguration UrlsConfiguration { get; private set; }

        public MetaDataConfiguration MetaDataConfiguration { get; private set; }
    }
}
