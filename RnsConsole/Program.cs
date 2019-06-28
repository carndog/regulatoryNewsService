using System;
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

            IFeedDownloader feedDownloader = root.Get();

            string content = await feedDownloader.Download("TW");
        }
    }
}
