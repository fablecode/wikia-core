using System;
using System.Threading.Tasks;
using wikia.Configuration;
using wikia.Enums;
using wikia.Helper;
using wikia.Models.Article;
using wikia.Models.Article.AlphabeticalList;
using wikia.Models.Article.NewArticles;
using wikia.Models.Article.PageList;

namespace wikia.Api
{
    public sealed class WikiArticleList : WikiArticleEndpoint, IWikiArticleList
    {
        public WikiArticleList(string domainUrl)
            : base(domainUrl, WikiaSettings.ApiVersion)
        {

        }
        public WikiArticleList(string domainUrl, string apiVersion)
            : base(domainUrl, apiVersion, new WikiaHttpClient())
        {

        }

        public WikiArticleList(string domainUrl, string apiVersion, IWikiaHttpClient wikiaHttpClient)
            : base(domainUrl, apiVersion, wikiaHttpClient)
        {
        }

        public Task<UnexpandedListArticleResultSet> AlphabeticalList(string category)
        {
            return AlphabeticalList(new ArticleListRequestParameters { Category = category });
        }

        public Task<UnexpandedListArticleResultSet> AlphabeticalList(ArticleListRequestParameters requestParameters)
        {
            return ArticleList<UnexpandedListArticleResultSet>(requestParameters, false);
        }

        public Task<ExpandedListArticleResultSet> PageList(string category)
        {
            return PageList(new ArticleListRequestParameters { Category = category });
        }

        public Task<ExpandedListArticleResultSet> PageList(ArticleListRequestParameters requestParameters)
        {
            return ArticleList<ExpandedListArticleResultSet>(requestParameters, true);
        }

        public async Task<T> ArticleList<T>(ArticleListRequestParameters requestParameters, bool expand)
        {
            if (requestParameters == null)
                throw new ArgumentNullException(nameof(requestParameters));

            var json = await ArticleRequest(ArticleEndpoint.List, () => ArticleHelper.GetListParameters(requestParameters, expand));

            return JsonHelper.Deserialize<T>(json);
        }

        public Task<NewArticleResultSet> NewArticles()
        {
            return NewArticles(new NewArticleRequestParameters());
        }

        public async Task<NewArticleResultSet> NewArticles(NewArticleRequestParameters requestParameters)
        {
            if (requestParameters == null)
                throw new ArgumentNullException(nameof(requestParameters));

            if (requestParameters.Limit <= 0 || requestParameters.Limit > 100)
                throw new ArgumentOutOfRangeException(nameof(requestParameters.Limit), "Minimum limit is 1 and maximum is 100.");

            if (requestParameters.MinArticleQuality <= 0 || requestParameters.MinArticleQuality > 99)
                throw new ArgumentOutOfRangeException(nameof(requestParameters.MinArticleQuality), "Minimal value of article quality. Ranges from 0 to 99.");

            var json = await ArticleRequest(ArticleEndpoint.NewArticles, () => ArticleHelper.GetNewArticleParameters(requestParameters));

            return JsonHelper.Deserialize<NewArticleResultSet>(json);
        }

    }
}