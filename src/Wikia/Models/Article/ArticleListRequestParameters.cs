using Refit;
using System.Collections.Generic;

namespace wikia.Models.Article
{
    public sealed record ArticleListRequestParameters(string Category)
    {
        /// <summary>
        /// Return only articles belonging to the provided valid category title
        /// </summary>
        [AliasAs(QuerystringParameter.Category)]
        public string Category { get; set; } = Category;

        /// <summary>
        /// Comma-separated namespace ids, see more: http://community.wikia.com/wiki/Help:Namespaces
        /// </summary>
        [AliasAs(QuerystringParameter.Namespaces)]
        [Query(CollectionFormat.Csv)]
        public HashSet<string> Namespaces { get; set; }

        /// <summary>
        /// Limit the number of results
        /// </summary>
        [AliasAs(QuerystringParameter.Limit)]
        public int Limit { get; set; } = 25;

        /// <summary>
        /// Lexicographically minimal article title.
        /// </summary>
        [AliasAs(QuerystringParameter.Offset)] 
        public string Offset { get; set; }

        /// <summary>
        /// Expand article.
        /// </summary>
        [AliasAs(QuerystringParameter.Expand)] 
        public string Expand { get; set; }
    }
}