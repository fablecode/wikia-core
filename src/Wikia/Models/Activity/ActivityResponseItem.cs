namespace wikia.Models.Activity
{
    public class ActivityResponseItem
    {
        public int Article { get; set; }
        public int User { get; set; }
        public int RevisionId { get; set; }
        public int Timestamp { get; set; }
    }
}