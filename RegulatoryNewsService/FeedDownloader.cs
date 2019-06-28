using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace RegulatoryNewsService
{
    public class FeedDownloader : IFeedDownloader
    {
        private readonly IHttpClient _client;

        private readonly IAppConfiguration _configuration;

        private readonly string baseUrl = "https://www.londonstockexchange.com/exchange/json/news/rns/{0}.html";

        ///https://www.londonstockexchange.com/exchange/news/market-news/market-news-detail/IDEA/14091639.html

        private readonly string searchUrl = "https://www.londonstockexchange.com/exchange/news/market-news/market-news-home.html?newsSource=RNR&nameCode=&headlineId=&ftseIndex=&sectorCode=&text=&newsPerPage=500&rbDate=released&preDate=Last3Months";

        public FeedDownloader(IHttpClient client, IAppConfiguration configuration)
        {
            _client = client;
            _configuration = configuration;
        }

        public async Task<string> Download(string symbol)
        {
            SymbolsConfiguration symbolsConfiguration = _configuration.SymbolsConfiguration;

            //string rnsJson = await _client.Download(string.Format(baseUrl, symbol));
            string rnsJson = await _client.Download(string.Format(searchUrl));

            return rnsJson;
        }
    }
}
