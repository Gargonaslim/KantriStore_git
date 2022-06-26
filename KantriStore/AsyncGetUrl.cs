using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace KantriStore
{
    public class AsyncGetUrl
    {
        IList<string> data = new List<string> { "https://kantriwebapp.azurewebsites.net/api/AllProducts/", "https://kantriwebapp.azurewebsites.net/api/SaleProducts/", "https://kantriwebapp.azurewebsites.net/api/NewProducts/",
                                                "https://kantriwebapp.azurewebsites.net/api/SpecifiedProducts/", "https://kantriwebapp.azurewebsites.net/api/HuntFishProducts/"};
        public async IAsyncEnumerable<string> GetDataAsync()
        {
            for (int i = 0; i < data.Count; i++)
            {
                await Task.Delay(500);
                yield return data[i];
            }
        }
    }
}
