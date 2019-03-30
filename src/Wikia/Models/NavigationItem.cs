using System.Collections.Generic;
using wikia.Models.Mercury;

namespace wikia.Models
{
    public class NavigationItem
    {
        /// <summary>
        /// On the wiki navigation bar data,
        /// </summary>
        public List<WikiaItem> Wikia { get; set; }

        /// <summary>
        /// User set navigation bars
        /// </summary>
        public List<WikiaItem> Wiki { get; set; }
    }
}