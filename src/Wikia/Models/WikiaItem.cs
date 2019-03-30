using System.Collections.Generic;

namespace wikia.Models
{
    public class WikiaItem
    {
        /// <summary>
        /// On wiki navigation bar text,
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// The relative URL of the Page. Absolute URL: obtained from combining relative URL with basepath attribute from response.
        /// </summary>
        public string Href { get; set; }

        /// <summary>
        /// Children collection containing article or special pages data
        /// </summary>
        public List<ChildrenItem> Children { get; set; }
    }
}