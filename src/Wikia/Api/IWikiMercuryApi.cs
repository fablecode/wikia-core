using System.Threading.Tasks;
using Refit;
using wikia.Constants;
using wikia.Models.Mercury;

namespace wikia.Api;

public interface IWikiMercuryApi
{
    [Get(ArticleEndpoint.Mercury)]
    Task<WikiDataContainer> WikiVariables();
}