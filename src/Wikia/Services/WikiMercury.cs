using System.Threading.Tasks;
using wikia.Api;
using wikia.Configuration;
using wikia.Models.Mercury;

namespace wikia.Services
{
    public sealed class WikiMercury : IWikiMercury
    {
        private readonly IWikiMercuryApi _wikiMercuryApi;

        public WikiMercury(string domainUrl)
            : this(WikiaRestService.For<IWikiMercuryApi>(domainUrl))
        {
        }

        public WikiMercury(IWikiMercuryApi wikiMercuryApi)
        {
            _wikiMercuryApi = wikiMercuryApi;
        }

        public Task<WikiDataContainer> WikiVariables()
        {
            return _wikiMercuryApi.WikiVariables();
        }
    }
}