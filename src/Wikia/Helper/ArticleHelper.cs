using System.Collections.Generic;
using System.Linq;
using wikia.Models.Activity;
using wikia.Models.Article;
using wikia.Models.Article.Details;
using wikia.Models.Article.NewArticles;
using wikia.Models.Article.Popular;

namespace wikia.Helper
{
    public static class ArticleHelper
    {

        public static IDictionary<string, string> GetDetailsParameters(ArticleDetailsRequestParameters requestParameters)
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>
            {
                [QuerystringParameter.Ids] = string.Join(",", requestParameters.Ids),
                ["abstract"] = requestParameters.Abstract.ToString(),
                ["width"] = requestParameters.ThumbnailWidth.ToString(),
                ["height"] = requestParameters.ThumbnailHeight.ToString(),
            };

            if (requestParameters.Titles != null && requestParameters.Titles.Any())
                parameters.Add("titles", string.Join(",", requestParameters.Titles));

            return parameters;
        }

        public static IDictionary<string, string> GetListParameters(ArticleListRequestParameters requestParameters)
        {
            return GetListParameters(requestParameters, false);
        }

        public static IDictionary<string, string> GetListParameters(ArticleListRequestParameters requestParameters, bool expanded)
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>
            {
                [QuerystringParameter.Limit] = requestParameters.Limit.ToString(),
            };

            if (expanded)
                parameters[QuerystringParameter.Expand] = "1";

            if (!string.IsNullOrEmpty(requestParameters.Category))
                parameters["category"] = requestParameters.Category;

            if (requestParameters.Namespaces.Any())
                parameters[QuerystringParameter.Namespaces] = string.Join(",", requestParameters.Namespaces);

            if (!string.IsNullOrEmpty(requestParameters.Offset))
                parameters["offset"] = requestParameters.Offset;

            return parameters;
        }

        public static IDictionary<string, string> GetNewArticleParameters(NewArticleRequestParameters requestParameters)
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>
            {
                [QuerystringParameter.Limit] = requestParameters.Limit.ToString(),
                [QuerystringParameter.MinArticleQuality] = requestParameters.MinArticleQuality.ToString(),
            };

            if (requestParameters.Namespaces.Any())
                parameters[QuerystringParameter.Namespaces] = string.Join(",", requestParameters.Namespaces);

            return parameters;
        }

        public static IDictionary<string, string> GetPopularArticleParameters(PopularArticleRequestParameters requestParameters)
        {
            return GetPopularArticleParameters(requestParameters, false);
        }

        public static IDictionary<string, string> GetPopularArticleParameters(PopularArticleRequestParameters requestParameters, bool expanded)
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>
            {
                [QuerystringParameter.Limit] = requestParameters.Limit.ToString(),
            };

            if (expanded)
                parameters[QuerystringParameter.Expand] = "1";

            if (requestParameters.BaseArticleId.HasValue)
                parameters["basearticleid"] = string.Join(",", requestParameters.BaseArticleId);

            return parameters;
        }

        public static IDictionary<string, string> GetActivityParameters(ActivityRequestParameters requestParameters)
        {
            var parameters = new Dictionary<string, string>
            {
                [QuerystringParameter.Limit] = requestParameters.Limit.ToString(),
                [QuerystringParameter.Namespaces] = string.Join(",", requestParameters.Namespaces),
                ["allowduplicates"] = requestParameters.AllowDuplicates.ToString().ToLower()
            };

            return parameters;
        }


    }
}