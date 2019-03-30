using System.Collections.Generic;

namespace wikia.Models.Article.Details
{
    public class ArticleDetailsRequestParameters
    {
        public ArticleDetailsRequestParameters(params int[] ids)
        {
            Ids = ids;
        }

        public int[] Ids { get; }

        /// <summary>
        /// Titles with underscores instead of spaces, comma-separated
        /// </summary>
        public List<string> Titles { get; set; } = new List<string>();

        /// <summary>
        /// The desired length for the article's text. Max 500.
        /// </summary>
        public int Abstract { get; set; } = 200;

        /// <summary>
        /// The desired width for the thumbnail
        /// </summary>
        public int ThumbnailWidth { get; set; } = 200;

        /// <summary>
        /// The desired height for the thumbnail
        /// </summary>
        public int ThumbnailHeight { get; set; } = 200;

    }
}