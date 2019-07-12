using System.Collections.Generic;
using System.Threading.Tasks;

namespace RegulatoryNewsService
{
    public interface ILinkDownloader
    {
        Task<IList<string>> DownloadAll();
    }
}