using System.Threading.Tasks;

namespace RegulatoryNewsService
{
    public class FeedDownloader : IFeedDownloader
    {
        private readonly IHttpClient _client;

        private readonly IAppConfiguration _configuration;

        public FeedDownloader(IHttpClient client, IAppConfiguration configuration)
        {
            _client = client;
            _configuration = configuration;
        }

        public async Task<string> Download()
        {
            UrlsConfiguration urlsConfiguration = _configuration.UrlsConfiguration;

            string rnsLinks = await _client.Download(string.Format(urlsConfiguration.SearchUrl));

            return rnsLinks;
        }
    }
}
