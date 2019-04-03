using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using wikia.Enums;

namespace wikia.Api
{
    public interface IWikiArticleEndpoint
    {
        Task<string> ArticleRequest(ArticleEndpoint endpoint, Func<IDictionary<string, string>> getParameters);
    }
}