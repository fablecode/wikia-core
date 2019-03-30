using System.Collections.Generic;

namespace wikia.Models.User
{
    public class UserRequestParameters
    {
        /// <summary>
        /// Comma-separated list of user ids. Maximum size of id list is 100.
        /// </summary>
        public HashSet<string> Ids { get; set; } = new HashSet<string>();

        /// <summary>
        /// The desired width (and height, because it is a square) for the thumbnail, defaults to 100, 0 for no thumbnail
        /// </summary>
        public int Size { get; set; } = 100;
    }
}