using System.Collections.Generic;
using System.Threading.Tasks;

namespace wikia
{
    public interface IWikiaHttpClient
    {
        Task<string> GetString(string url);
        Task<string> GetString(string url, IDictionary<string, string> parameters);
    }
}