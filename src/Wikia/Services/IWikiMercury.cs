using System.Threading.Tasks;
using wikia.Models.Mercury;

namespace wikia.Services
{
    public interface IWikiMercury
    {
        Task<WikiDataContainer> WikiVariables();
    }
}