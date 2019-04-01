using System.Threading.Tasks;
using wikia.Models;

namespace wikia.Api
{
    public interface IWikiNavigation
    {
        Task<NavigationResultSet> NavigationLinks();
    }
}