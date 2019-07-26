using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RegulatoryNewsService.Configurations;

namespace RegulatoryNewsService
{
    public class CompanyNewsSearcher : ICompanyNewsSearcher
    {
        private readonly IAppConfiguration _configuration;

        private readonly ILinkDownloader _downloader;

        public CompanyNewsSearcher(IAppConfiguration configuration, ILinkDownloader downloader)
        {
            _configuration = configuration;
            _downloader = downloader;
        }

        public async Task<IList<string>> Filter()
        {
            SearchConfiguration searchConfiguration = _configuration.SearchConfiguration;

            IList<string> allAnnouncements = await _downloader.DownloadAll();

            IEnumerable<string> results = allAnnouncements
                .Where(x => searchConfiguration.Phrases.Any(phrase => x.IndexOf(phrase, StringComparison.OrdinalIgnoreCase) != -1));

            return results.ToList();
        }
    }
}
