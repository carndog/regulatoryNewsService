using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegulatoryNewsService
{
    public class LinkDownloader : ILinkDownloader
    {
        private readonly IUrlLinkProvider _linkProvider;

        private readonly IHttpClient _httpClient;

        public LinkDownloader(IUrlLinkProvider linkProvider, IHttpClient httpClient)
        {
            _linkProvider = linkProvider;
            _httpClient = httpClient;
        }

        public async Task<IList<string>> DownloadAll()
        {
            List<string> urls = await _linkProvider.CreateUrls();

            IEnumerable<Task<string>> downloadTasks = urls.Select(uri => _httpClient.Download(uri));

            string[] data = await Task.WhenAll(downloadTasks);

            return data;
        }
    }
}
