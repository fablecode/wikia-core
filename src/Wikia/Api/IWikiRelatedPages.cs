using System.Threading.Tasks;
using wikia.Models.RelatedPages;

namespace wikia.Api
{
    public interface IWikiRelatedPages
    {
        Task<RelatedPages> Articles(params int[] ids);
        Task<RelatedPages> Articles(RelatedArticlesRequestParameters requestParameters);
    }
}