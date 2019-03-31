using System.Collections.Generic;
using System.Linq;
using wikia.Models.Article.Details;

namespace wikia.Helper
{
    public static class ArticleHelper
    {
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
    }
}