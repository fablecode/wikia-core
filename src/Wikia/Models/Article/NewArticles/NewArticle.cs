namespace wikia.Models.Article.NewArticles
{
    public class NewArticle
    {
        /// <summary>
        /// Quality score of the article, ranges from 0 (low quality) to 99 (high quality),
        /// </summary>
        public int Quality { get; set; }

        /// <summary>
        /// The original dimensions of the thumbnail for the article, if available
        /// </summary>
        public OriginalDimension Original_Dimensions { get; set; }

        /// <summary>
        /// The relative URL of the Article. Absolute URL: obtained from combining relative URL with basepath attribute from response.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// The namespace value of the given article
        /// </summary>
        public int NS { get; set; }

        /// <summary>
        /// A snippet of text from the beginning of the article,
        /// </summary>
        public string Abstract { get; set; }

        /// <summary>
        /// Data about the author of the article (creator of the first revision)
        /// </summary>
        public Creator Creator { get; set; }

        /// <summary>
        /// The absolute URL of the thumbnail
        /// </summary>
        public string Thumbnail { get; set; }

        /// <summary>
        /// Date of the first revision of the article,
        /// </summary>
        public string Creation_Date { get; set; }

        /// <summary>
        /// An internal identification number for Article,
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The title of the article,
        /// </summary>
        public string Title { get; set; }
    }
}