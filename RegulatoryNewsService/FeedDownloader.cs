using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HtmlAgilityPack;

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

            string rnsLinks = await _client.Download(string.Format(searchUrl));

            HtmlDocument document = new HtmlDocument();

            document.LoadHtml(rnsLinks);

            IEnumerable<HtmlNode> htmlNodes = document.DocumentNode.Descendants()
                .Where(x => x.Name == "td")
                .Where(x => x.HasClass("RNS_data"));

            IEnumerable<HtmlAttribute> htmlAttributes = htmlNodes.SelectMany(x => x.Attributes.Where(y => y.Name == "href"))
                .Where(x => x.Value.Contains("/exchange/news"));

            IEnumerable<string> values = htmlAttributes.Select(x => x.Value);

            //enumerable.First().Attributes.Where(x => x.Name == "href").First(x => x.Value.Contains("/exchange/news")).Value

            return rnsLinks;
        }
    }
}
