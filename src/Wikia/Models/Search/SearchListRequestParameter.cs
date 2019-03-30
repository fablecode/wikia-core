using System.Collections.Generic;

namespace wikia.Models.Search
{
    public class SearchListRequestParameter
    {
        public SearchListRequestParameter(string query)
        {
            Query = query;
        }

        /// <summary>
        /// Search query
        /// </summary>
        public string Query { get; set; }

        /// <summary>
        /// The search type, either articles (default) or videos. For 'videos' value, this parameter should be used with namespaces parameter (namespaces needs to be set to 6)
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The ranking to use in fetching the list of results, one of default, newest, oldest, recently-modified, stable, most-viewed, freshest, stalest
        /// </summary>
        public string Rank { get; set; }

        /// <summary>
        /// Limit the number of results
        /// </summary>
        public int Limit { get; set; } = 25;

        /// <summary>
        /// Minimal value of article quality. Ranges from 0 to 99
        /// </summary>
        public int MinArticleQuality { get; set; } = 10;

        /// <summary>
        /// The batch (page) of results to fetch
        /// </summary>
        public int Batch { get; set; } = 1;

        /// <summary>
        /// Comma-separated namespace ids, see more: http://community.wikia.com/wiki/Help:Namespaces
        /// </summary>
        public HashSet<string> Namespaces { get; set; } = new HashSet<string>{"0", "14"};
    }
}