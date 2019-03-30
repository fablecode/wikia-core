namespace wikia.Models.RelatedPages
{
    public class RelatedArticlesRequestParameters
    {
        /// <summary>
        /// Comma-separated list of article ids
        /// </summary>
        public int[] Ids { get; set; }

        /// <summary>
        /// Limit the number of results
        /// </summary>
        public int Limit { get; set; } = 3;
    }
}