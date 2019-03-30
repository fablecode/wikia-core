using System.Collections.Generic;

namespace wikia.Models.RelatedPages
{
    public class RelatedPages
    {
        /// <summary>
        /// Standard container name for element collection (list),
        /// </summary>
        public Dictionary<string, RelatedPage[]> Items { get; set; }

        /// <summary>
        /// Offset to start next batch of data,
        /// </summary>
        public string Offset { get; set; }

        /// <summary>
        /// Common URL prefix for relative URLs
        /// </summary>
        public string Basepath { get; set; }
    }
}