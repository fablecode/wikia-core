using Newtonsoft.Json;

namespace wikia.Models.Article.AlphabeticalList
{
    public class UnexpandedListArticleResultSet
    {
        /// <summary>
        /// Standard container name for element collection (list),
        /// </summary>
        public UnexpandedArticle[] Items { get; set; }

        /// <summary>
        /// Offset to start next batch of data,
        /// </summary>
        public string Offset { get; set; }

        /// <summary>
        /// Common URL prefix for relative URLs
        /// </summary>
        public string Basepath { get; set; }
    }
}