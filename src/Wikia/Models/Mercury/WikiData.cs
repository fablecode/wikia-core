using System.Collections.Generic;

namespace wikia.Models.Mercury
{
    public class WikiData
    {
        public string CacheBuster { get; set; }
        public string DbName { get; set; }
        public string DefaultSkin { get; set; }
        public string Id { get; set; }
        public WikiLanguageData Language { get; set; }
        public IDictionary<string, string> Namespaces { get; set; }
        public string Sitename { get; set; }
        public string MainPageTitle { get; set; }
        public List<string> WikiCategories { get; set; }
        public NavigationResultSet NavData { get; set; }
        public string Vertical { get; set; }
        public string BasePath { get; set; }
        public string IsGaSpecialWiki { get; set; }
        public string ArticlePath { get; set; }
        public string FacebookAppId { get; set; }
    }
}