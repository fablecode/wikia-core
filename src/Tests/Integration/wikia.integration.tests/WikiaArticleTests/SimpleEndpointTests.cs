using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using wikia.Api;
using wikia.tests.core;

namespace wikia.integration.tests.WikiaArticleTests
{
    [TestFixture]
    [Category(TestType.Integration)]
    public class SimpleEndpointTests
    {
        [TestCaseSource(typeof(WikiaTestData), nameof(WikiaTestData.ArticleIdTestUrlData))]
        public async Task Given_A_DomainUrl_And_ArticleId_SectionList_Should_Not_Be_Empty(string domainUrl, int articleId)
        {
            // Arrange
            IWikiArticle sut = new WikiArticle(domainUrl);

            // Act
            var result = await sut.Simple(articleId);

            // Assert
            result.Sections.Should().NotBeEmpty();
        }
    }
}
