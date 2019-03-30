using System.Collections.Generic;

namespace wikia.Models.Activity
{
    public class ActivityResponseResult
    {
        public IList<ActivityResponseItem> Items { get; set; }
        public string Basepath { get; set; }
    }
}