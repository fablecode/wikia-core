using System;

namespace wikia.Helper
{
    public class UrlHelper
    {
        public static string GenerateUrl(string absoluteUrl, string relativeUrl)
        {
            if (!absoluteUrl.EndsWith("/"))
                absoluteUrl += "/";

            if (relativeUrl.StartsWith("/"))
                relativeUrl = relativeUrl.TrimStart('/');

            var absoluteUri = new Uri(absoluteUrl);
            var relativeUri = new Uri(relativeUrl, UriKind.Relative);

            return new Uri(absoluteUri, relativeUri).AbsoluteUri;
        }
    }
}