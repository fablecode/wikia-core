using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Refit;
using System.Threading.Tasks;
using wikia.Api;

namespace wikia.Configuration
{
    public static class WikiaSettings
    {
        public const string ApiVersion = "api/v1";
    }
    public static class WikiaRestService
    {
        public static T For<T>(string domainUrl)
        {
            return RestService.For<T>(domainUrl,
                new RefitSettings
                {
                    ContentSerializer = new NewtonsoftJsonContentSerializer(
                        new JsonSerializerSettings()
                        {
                            ContractResolver = new CamelCasePropertyNamesContractResolver(),
                            Converters = { new StringEnumConverter() }
                        }
                    )
                });
        }
    }
}