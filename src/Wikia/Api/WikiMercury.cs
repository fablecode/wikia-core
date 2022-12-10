using System.Threading.Tasks;
using wikia.Configuration;
using wikia.Models.Mercury;

namespace wikia.Api
{
    public sealed class WikiMercury : IWikiMercury
    {
        private readonly IWikiMercuryApi _wikiMercuryApi;
        private readonly IWikiaHttpClient _wikiaHttpClient;
        private readonly string _wikiApiUrl;
        private const string WikiVariablesUrl = "Mercury/WikiVariables";

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