using System.Net.Http;
using System.Threading.Tasks;

namespace RegulatoryNewsService
{
    public class HttpDownloadClient : IHttpClient
    {
        public async Task<string> Download(string uri)
        {
            HttpClient downloadClient = new HttpClient();

            HttpResponseMessage message = await downloadClient.GetAsync(uri);

            string content = await message.Content.ReadAsStringAsync();

            return content;
        }
    }
}