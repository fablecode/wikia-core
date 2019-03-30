using System.Collections.Generic;

namespace wikia.Models.Article.NewArticles
{
    public class NewArticleRequestParameters
    {
        /// <summary>
        /// Comma-separated namespace ids, see more: http://community.wikia.com/wiki/Help:Namespaces
        /// </summary>
        public HashSet<string> Namespaces { get; set; } = new HashSet<string>();

        /// <summary>
        /// Limit the number of result - maximum limit is 100
        /// </summary>
        public int Limit { get; set; } = 20;

        /// <summary>
        /// Minimal value of article quality. Ranges from 0 to 99
        /// </summary>
        public int MinArticleQuality { get; set; } = 10;
    }
}