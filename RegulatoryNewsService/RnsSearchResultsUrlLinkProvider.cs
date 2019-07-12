using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace RegulatoryNewsService
{
    public class RnsSearchResultsUrlLinkProvider : IUrlLinkProvider
    {
        private readonly IAppConfiguration _configuration;

        private readonly IFeedDownloader _feedDownloader;

        public RnsSearchResultsUrlLinkProvider(IAppConfiguration configuration, IFeedDownloader feedDownloader)
        {
            _configuration = configuration;
            _feedDownloader = feedDownloader;
        }

        public async Task<List<string>> CreateUrls()
        {
            MetaDataConfiguration metaDataConfiguration = _configuration.MetaDataConfiguration;

            SymbolsConfiguration symbolsConfiguration = _configuration.SymbolsConfiguration;

            UrlsConfiguration urlsConfiguration = _configuration.UrlsConfiguration;

            HtmlDocument document = new HtmlDocument();

            document.LoadHtml(await _feedDownloader.Download());

            IEnumerable<HtmlNode> htmlNodes = document.DocumentNode.Descendants()
                .Where(x => x.Name == "td")
                .Where(x => x.HasClass("RNS_data"));

            List<string> urls = new List<string>(500);

            foreach (HtmlNode htmlNode in htmlNodes)
            {
                int startIndex = htmlNode.OuterHtml.IndexOf("/exchange/news/market-news", StringComparison.OrdinalIgnoreCase);

                if (startIndex != -1)
                {
                    int endIndex = htmlNode.OuterHtml.IndexOf(metaDataConfiguration.Extension, startIndex, StringComparison.OrdinalIgnoreCase);

                    if (endIndex != -1)
                    {
                        string value = htmlNode.OuterHtml.Substring(startIndex, (endIndex - startIndex) + metaDataConfiguration.Extension.Length);

                        if (symbolsConfiguration.Symbols.Any(x => value.IndexOf(x, StringComparison.Ordinal) != -1))
                        {
                            string url = urlsConfiguration.BaseUrl + value;

                            urls.Add(url);
                        }
                    }
                }
            }

            return urls;
        }
    }
}
