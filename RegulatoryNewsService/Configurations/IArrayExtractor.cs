using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace RegulatoryNewsService.Configurations
{
    public interface IArrayExtractor
    {
        IList<string> ExtractValues(string path, IConfigurationRoot configurationRoot);
    }
}