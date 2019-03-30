using System.Collections.Generic;

namespace wikia.Models.Search
{
    public class LocalWikiSearchResultSet
    {
        public string Batches { get; set; }
        public IList<LocalWikiSearchResult> Items { get; set; }
        public string Total { get; set; }
        public string CurrentBatch { get; set; }
        public string Next { get; set; }
    }
}