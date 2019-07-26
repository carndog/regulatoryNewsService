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

            ILinkDownloader feedDownloader = root.Get();

            IList<string> companyNewsDownloads = await feedDownloader.DownloadAll();
        }
    }
}
