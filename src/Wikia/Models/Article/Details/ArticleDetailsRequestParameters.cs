using System.Collections.Generic;
using Refit;

namespace wikia.Models.Article.Details
{
    public class ArticleDetailsRequestParameters
    {
        public ArticleDetailsRequestParameters(params int[] ids)
        {
            Ids = ids;
        }

        [AliasAs(QuerystringParameter.Ids)]
        public int[] Ids { get; }

        /// <summary>
        /// Titles with underscores instead of spaces, comma-separated
        /// </summary>
        [AliasAs(QuerystringParameter.Titles)]
        [Query(CollectionFormat.Csv)]
        public List<string> Titles { get; set; }

        /// <summary>
        /// The desired length for the article's text. Max 500.
        /// </summary>
        [AliasAs(QuerystringParameter.Abstract)]
        public int Abstract { get; set; } = 200;

        /// <summary>
        /// The desired width for the thumbnail
        /// </summary>
        [AliasAs(QuerystringParameter.Width)]
        public int ThumbnailWidth { get; set; } = 200;

        /// <summary>
        /// The desired height for the thumbnail
        /// </summary>
        [AliasAs(QuerystringParameter.Height)]
        public int ThumbnailHeight { get; set; } = 200;

    }
}