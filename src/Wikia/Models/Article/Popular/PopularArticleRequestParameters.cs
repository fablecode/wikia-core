namespace wikia.Models.Article.Popular
{
    public class PopularArticleRequestParameters
    {
        /// <summary>
        /// Limit the number of result - maximum limit is 10
        /// </summary>
        public int Limit { get; set; } = 10;

        /// <summary>
        /// Trending and popular related to article with given id
        /// </summary>
        public int? BaseArticleId { get; set; }
    }
}