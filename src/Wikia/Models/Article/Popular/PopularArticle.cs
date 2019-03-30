namespace wikia.Models.Article.Popular
{
    public class PopularArticle
    {
        /// <summary>
        /// An internal identification number for Article,
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The title of the article,
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The relative URL of the Article. Absolute URL: obtained from combining relative URL with basepath attribute from response.
        /// </summary>
        public string Url { get; set; }
    }
}