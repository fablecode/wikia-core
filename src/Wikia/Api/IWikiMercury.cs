using System.Threading.Tasks;
using wikia.Models.Mercury;

namespace wikia.Api
{
    public interface IWikiMercury
    {
        Task<WikiDataContainer> WikiVariables();
    }
}