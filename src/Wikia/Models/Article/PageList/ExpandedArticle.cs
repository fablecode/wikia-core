namespace wikia.Models.Article.PageList
{
    public class ExpandedArticle
    {
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
        /// The absolute URL of the thumbnail
        /// </summary>
        public string Thumbnail { get; set; }

        /// <summary>
        /// The latest revision for this article,
        /// </summary>
        public Revision Revision { get; set; }

        /// <summary>
        /// An internal identification number for Article,
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The title of the article,
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The functional type of the document (e.g. article, file, category),
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Number of comments on this article
        /// </summary>
        public int Comments { get; set; }
    }
}