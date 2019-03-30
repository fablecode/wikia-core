namespace wikia.Models
{
    public class ChildrenItem
    {
        /// <summary>
        /// Article or special page title,
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// The relative URL of the Page. Absolute URL: obtained from combining relative URL with basepath attribute from response.
        /// </summary>
        public string Href { get; set; }
    }
}