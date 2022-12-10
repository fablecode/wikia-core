namespace wikia.Constants;

public static class ArticleEndpoint
{
    public const string ApiVersion = "/api/v1";
    public const string Simple = $"{ApiVersion}/Articles/AsSimpleJson";
    public const string Details = $"{ApiVersion}/Articles/Details";
    public const string List = $"{ApiVersion}/Articles/List";
    public const string NewArticles = $"{ApiVersion}/Articles/New";
    public const string Popular = $"{ApiVersion}/Articles/Popular";
    public const string Mercury = $"{ApiVersion}/Mercury/WikiVariables";
    public const string SearchSuggestions = $"{ApiVersion}/SearchSuggestions/List";
}