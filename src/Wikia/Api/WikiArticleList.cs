using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Refit;
using System;
using System.Threading.Tasks;
using wikia.Helper;
using wikia.Models.Article;
using wikia.Models.Article.AlphabeticalList;
using wikia.Models.Article.NewArticles;
using wikia.Models.Article.PageList;
using wikia.Models.Article.Popular;
using wikia.Services;

namespace wikia.Api
{
    public sealed class WikiArticleList : IWikiArticleList
    {
        private readonly IWikiArticleListApi _wikiArticleListApi;

        public WikiArticleList(string domainUrl)
        {
            _wikiArticleListApi = RestService.For<IWikiArticleListApi>(domainUrl,
                new RefitSettings
                {
                    ContentSerializer = new NewtonsoftJsonContentSerializer(
                        new JsonSerializerSettings()
                        {
                            ContractResolver = new CamelCasePropertyNamesContractResolver(),
                            Converters = { new StringEnumConverter() }
                        }
                    )
                });
        }
        public WikiArticleList(string domainUrl, string apiVersion)
            //: base(domainUrl, apiVersion, new WikiaHttpClient())
        {

        }

        public WikiArticleList(string domainUrl, string apiVersion, IWikiaHttpClient wikiaHttpClient)
            //: base(domainUrl, apiVersion, wikiaHttpClient)
        {
        }

        public Task<UnexpandedListArticleResultSet> AlphabeticalList(string category)
        {
            return AlphabeticalList(new ArticleListRequestParameters(category));
        }

        public Task<UnexpandedListArticleResultSet> AlphabeticalList(ArticleListRequestParameters requestParameters)
        {
            return _wikiArticleListApi.AlphabeticalList(requestParameters);
        }

        public Task<ExpandedListArticleResultSet> PageList(string category)
        {
            return PageList(new ArticleListRequestParameters(category));
        }

        public Task<ExpandedListArticleResultSet> PageList(ArticleListRequestParameters requestParameters)
        {
            requestParameters.Expand = "1";
            return _wikiArticleListApi.PageList(requestParameters);
        }

        public async Task<T> ArticleList<T>(ArticleListRequestParameters requestParameters, bool expand)
        {
            if (requestParameters == null)
                throw new ArgumentNullException(nameof(requestParameters));

            //var json = await ArticleRequest(ArticleEndpoint.List, () => ArticleHelper.GetListParameters(requestParameters, expand));

            return JsonHelper.Deserialize<T>(string.Empty);
        }

        public Task<NewArticleResultSet> NewArticles()
        {
            return NewArticles(new NewArticleRequestParameters());
        }

        public Task<NewArticleResultSet> NewArticles(NewArticleRequestParameters requestParameters)
        {
            if (requestParameters == null)
                throw new ArgumentNullException(nameof(requestParameters));

            if (requestParameters.Limit is <= 0 or > 100)
                throw new ArgumentOutOfRangeException(nameof(requestParameters.Limit), "Minimum limit is 1 and maximum is 100.");

            if (requestParameters.MinArticleQuality is <= 0 or > 99)
                throw new ArgumentOutOfRangeException(nameof(requestParameters.MinArticleQuality), "Minimal value of article quality. Ranges from 0 to 99.");

            return _wikiArticleListApi.NewArticles(requestParameters);
        }

        public Task<PopularListArticleResultSet> PopularArticleSimple(PopularArticleRequestParameters requestParameters)
        {
            return PopularArticle<PopularListArticleResultSet>(requestParameters, false);
        }

        public Task<PopularExpandedArticleResultSet> PopularArticleDetail(PopularArticleRequestParameters requestParameters)
        {
            return PopularArticle<PopularExpandedArticleResultSet>(requestParameters, true);
        }

        public async Task<T> PopularArticle<T>(PopularArticleRequestParameters requestParameters, bool expand)
        {
            if (requestParameters == null)
                throw new ArgumentNullException(nameof(requestParameters));

            if (requestParameters.Limit <= 0 || requestParameters.Limit > 10)
                throw new ArgumentOutOfRangeException(nameof(requestParameters.Limit), "Minimum limit is 1 and maximum is 10");

            //var json = await ArticleRequest(ArticleEndpoint.Popular, () => ArticleHelper.GetPopularArticleParameters(requestParameters, true));

            return JsonHelper.Deserialize<T>("json");
        }

    }
}