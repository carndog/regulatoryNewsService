using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace RegulatoryNewsService.Configurations
{
    public class ArrayExtractor : IArrayExtractor
    {
        public IList<string> ExtractValues(string path, IConfigurationRoot configurationRoot)
        {
            List<string> values = new List<string>(20);
            string value = null;
            int i = 0;
            do
            {
                value = configurationRoot.GetSection(path)[i++.ToString()];
                if (value != null)
                {
                    values.Add(value);
                }
            }
            while (value != null);

            return values;
        }
    }
}
