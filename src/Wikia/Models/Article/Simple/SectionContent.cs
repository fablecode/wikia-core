namespace wikia.Models.Article.Simple
{
    public class SectionContent
    {
        public string Type { get; set; }
        public string Text { get; set; }
        public ListElement[] Elements { get; set; }
    }
}