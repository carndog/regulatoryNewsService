using System.Collections.Generic;
using System.Threading.Tasks;

namespace RegulatoryNewsService
{
    public interface ICompanyNewsSearcher
    {
        Task<IList<string>> Filter();
    }
}