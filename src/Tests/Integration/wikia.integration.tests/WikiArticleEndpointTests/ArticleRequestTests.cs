using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using wikia.Api;
using wikia.Configuration;
using wikia.Enums;
using wikia.tests.core;

namespace wikia.unit.tests.WikiArticleEndpointTests
{
    [TestFixture]
    [Category(TestType.Unit)]
    public class ArticleRequestTests
    {
        private WikiArticleEndpoint _sut;
        private const string Url = "http://naruto.wikia.com";

        [SetUp]
        public void Setup()
        {
            _sut = new WikiArticle(Url);
        }

        [Test]
        public async Task Given_An_ArticleEndPoint_And_Parameters_Should_Invoke_GetString_Once()
        {
            // Arrange
            const long articleId = 2342;

            // Act
            await _sut.ArticleRequest(ArticleEndpoint.Simple, () => new Dictionary<string, string> {["id"] = articleId.ToString()});

            // Assert
            //await _wikiaHttpClient.Received(1).GetString(Arg.Any<string>(), Arg.Any<Dictionary<string, string>>());
        }
    }
}