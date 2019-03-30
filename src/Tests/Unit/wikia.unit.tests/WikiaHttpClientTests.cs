using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using wikia.tests.core;

namespace wikia.unit.tests
{
    [TestFixture]
    [Category(TestType.Unit)]
    public class WikiaHttpClientTests
    {
        private WikiaHttpClient _sut;
        private IHttpClientFactory _httpClientFactory;

        [SetUp]
        public void Setup()
        {
            _httpClientFactory = Substitute.For<IHttpClientFactory>();
            _sut = new WikiaHttpClient(_httpClientFactory);
        }

        [Test]
        public async Task Given_A_Good_Url_Should_Return_String_Response()
        {
            // Arrange
            const string url = "http://good.uri";
            const string expected = "response";
            var fakeHttpMessageHandler = new FakeHttpMessageHandler(new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent("response", Encoding.UTF8, "application/json")
            });
            var fakeHttpClient = new HttpClient(fakeHttpMessageHandler);
            _httpClientFactory.CreateClient().Returns(fakeHttpClient);
            
            // Act
            var result = await _sut.GetString(url);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }


        [Test]
        public async Task Given_A_Good_Url_Should_Return_Invoke_CreateClient_Once()
        {
            // Arrange
            const string url = "http://good.uri";
            var fakeHttpMessageHandler = new FakeHttpMessageHandler(new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent("response", Encoding.UTF8, "application/json")
            });
            var fakeHttpClient = new HttpClient(fakeHttpMessageHandler);
            _httpClientFactory.CreateClient().Returns(fakeHttpClient);
            
            // Act
            var result = await _sut.GetString(url);

            // Assert
            _httpClientFactory.Received(1).CreateClient();
        }
    }
}