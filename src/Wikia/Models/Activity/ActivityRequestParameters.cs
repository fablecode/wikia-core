using System.Collections.Generic;

namespace wikia.Models.Activity
{
    public class ActivityRequestParameters
    {
        /// <summary>
        /// Limit the number of results
        /// </summary>
        public int Limit { get; set; } = 10;

        /// <summary>
        /// Comma-separated namespace ids, see more: http://community.wikia.com/wiki/Help:Namespaces
        /// </summary>
        public HashSet<string> Namespaces { get; set; } = new HashSet<string>();

        /// <summary>
        /// Set if duplicates of articles are not allowed. Default value is true
        /// </summary>
        public bool AllowDuplicates { get; set; } = true;
    }
}