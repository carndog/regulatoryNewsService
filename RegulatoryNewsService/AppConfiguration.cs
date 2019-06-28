﻿using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace RegulatoryNewsService
{
    public class AppConfiguration : IAppConfiguration
    {
        public AppConfiguration()
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json", false, true);

            IConfigurationRoot configurationRoot = configurationBuilder.Build();

            BuildSymbolsConfiguration(configurationRoot);
        }

        private void BuildSymbolsConfiguration(IConfigurationRoot configurationRoot)
        {
            List<string> symbols = new List<string>(20);
            string symbol = null;
            int i = 0;
            do
            {
                symbol = configurationRoot.GetSection("Symbols:Interest")[i++.ToString()];
                if (symbol != null)
                {
                    symbols.Add(symbol);
                }
            }
            while (symbol != null);

            SymbolsConfiguration = new SymbolsConfiguration
            {
                Symbols = symbols.ToArray()
            };
        }

        public SymbolsConfiguration SymbolsConfiguration { get; private set; }
    }
}
