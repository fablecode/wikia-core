using wikia.Api;

namespace wikia.Models.Article.NewArticles
{
    public class NewArticleResultSet
    {
        /// <summary>
        /// Standard container name for element collection (list),
        /// </summary>
        public NewArticle[] Items { get; set; }

        /// <summary>
        /// Common URL prefix for relative URLs
        /// </summary>
        public string Basepath { get; set; }
    }
}