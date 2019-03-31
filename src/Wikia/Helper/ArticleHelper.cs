using System.Collections.Generic;
using System.Linq;
using wikia.Models.Article;
using wikia.Models.Article.Details;
using wikia.Models.Article.NewArticles;

namespace wikia.Helper
{
    public static class ArticleHelper
    {
        public const string Limit = "limit";

        public static IDictionary<string, string> GetDetailsParameters(ArticleDetailsRequestParameters requestParameters)
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>
            {
                ["ids"] = string.Join(",", requestParameters.Ids),
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
                [Limit] = requestParameters.Limit.ToString(),
            };

            if (expanded)
                parameters["expand"] = "1";

            if (!string.IsNullOrEmpty(requestParameters.Category))
                parameters["category"] = requestParameters.Category;

            if (requestParameters.Namespaces.Any())
                parameters["namespaces"] = string.Join(",", requestParameters.Namespaces);

            if (!string.IsNullOrEmpty(requestParameters.Offset))
                parameters["offset"] = requestParameters.Offset;

            return parameters;
        }

        public static IDictionary<string, string> GetNewArticleParameters(NewArticleRequestParameters requestParameters)
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>
            {
                [Limit] = requestParameters.Limit.ToString(),
                ["minArticleQuality"] = requestParameters.MinArticleQuality.ToString(),
            };

            if (requestParameters.Namespaces.Any())
                parameters["namespaces"] = string.Join(",", requestParameters.Namespaces);

            return parameters;
        }

    }
}