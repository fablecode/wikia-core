using System.Collections.Generic;

namespace wikia.Models.Article
{
    public class ArticleListRequestParameters
    {
        /// <summary>
        /// Return only articles belonging to the provided valid category title
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Comma-separated namespace ids, see more: http://community.wikia.com/wiki/Help:Namespaces
        /// </summary>
        public HashSet<string> Namespaces { get; set; } = new HashSet<string>();

        /// <summary>
        /// Limit the number of results
        /// </summary>
        public int Limit { get; set; } = 25;

        /// <summary>
        /// Lexicographically minimal article title.
        /// </summary>
        public string Offset { get; set; }
    }
}