using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure;
using RegulatoryNewsService;

namespace RnsConsole
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            CompositionRoot root = new CompositionRoot();
            root.Start();

            ICompanyNewsSearcher companyNewsSearcher = root.Get();

            IList<string> companyNewsDownloads = await companyNewsSearcher.Filter();
        }
    }
}
