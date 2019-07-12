using System.Collections.Generic;
using System.Threading.Tasks;

namespace RegulatoryNewsService
{
    public interface IUrlLinkProvider
    {
        Task<List<string>> CreateUrls();
    }
}