namespace wikia.Models.Article.PageList
{
    public class ExpandedListArticleResultSet
    {
        /// <summary>
        /// Standard container name for element collection (list),
        /// </summary>
        public ExpandedArticle[] Items { get; set; }

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