using Refit;
using System.Collections.Generic;

namespace wikia.Models.Article.NewArticles
{
    public sealed record NewArticleRequestParameters
    {
        /// <summary>
        /// Comma-separated namespace ids, see more: http://community.wikia.com/wiki/Help:Namespaces
        /// </summary>
        [AliasAs(QuerystringParameter.Namespaces)]
        [Query(CollectionFormat.Csv)]
        public HashSet<string> Namespaces { get; set; }

        /// <summary>
        /// Limit the number of result - maximum limit is 100
        /// </summary>
        [AliasAs(QuerystringParameter.Limit)]
        public int Limit { get; set; } = 20;

        /// <summary>
        /// Minimal value of article quality. Ranges from 0 to 99
        /// </summary>
        [AliasAs(QuerystringParameter.MinArticleQuality)]
        public int MinArticleQuality { get; set; } = 10;
    }
}