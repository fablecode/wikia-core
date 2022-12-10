using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Refit;

namespace wikia.Configuration
{
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