using System.Threading.Tasks;

namespace RegulatoryNewsService
{
    public interface IHttpClient
    {
        Task<string> Download(string uri);
    }
}
