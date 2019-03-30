namespace wikia.Models.Article.Simple
{
    public class Section
    {
        public string Title { get; set; }
        public int Level { get; set; }
        public SectionContent[] Content { get; set; }
        public SectionImages[] Images { get; set; }

    }
}