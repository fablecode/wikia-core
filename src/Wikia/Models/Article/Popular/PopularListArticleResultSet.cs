using wikia.Models.Article.AlphabeticalList;

namespace wikia.Models.Article.Popular
{
    public class PopularListArticleResultSet
    {
        /// <summary>
        /// Standard container name for element collection (list),
        /// </summary>
        public PopularArticle[] Items { get; set; }

        /// <summary>
        /// Common URL prefix for relative URLs
        /// </summary>
        public string Basepath { get; set; }
    }
}