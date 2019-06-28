using System.IO;
using Microsoft.Extensions.Configuration;

namespace RegulatoryNewsService
{
    public class AppConfiguration : IAppConfiguration
    {
        private string[] _symbols;

        public AppConfiguration()
        {
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            string path = Path.Combine(Directory.GetCurrentDirectory(), "appSettings.json");
            configurationBuilder.AddJsonFile(path, false);

            IConfigurationRoot configurationRoot = configurationBuilder.Build();
            IConfigurationSection configurationSection = configurationRoot.GetSection("Symbols").GetSection("Interest");

            SymbolsConfiguration = new SymbolsConfiguration();
        }

        public SymbolsConfiguration SymbolsConfiguration { get; }
    }
}
