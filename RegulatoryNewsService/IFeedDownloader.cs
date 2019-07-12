using System.Threading.Tasks;

namespace RegulatoryNewsService
{
    public interface IFeedDownloader
    {
        Task<string> Download();
    }
}