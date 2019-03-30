namespace wikia.Models.Article
{
    public class Revision
    {
        /// <summary>
        /// An internal identification number for Revision
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the user who made the revision,
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// An internal identification number for User,
        /// </summary>
        public int User_Id { get; set; }

        /// <summary>
        /// The Unix timestamp (in seconds) that the revision was made
        /// </summary>
        public int Timestamp { get; set; }
    }
}