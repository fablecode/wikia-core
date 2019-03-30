namespace wikia.Models.Article.Popular
{
    public class PopularExpandedArticle
    {
        public OriginalDimension Original_Dimensions { get; set; }
        public string Url { get; set; }
        public int NS { get; set; }
        public string Abstract { get; set; }
        public string Thumbnail { get; set; }
        public Revision Revision { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public int Comments { get; set; }
        
    }
}