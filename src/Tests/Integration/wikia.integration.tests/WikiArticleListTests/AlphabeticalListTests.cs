using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using wikia.Api;
using wikia.Configuration;
using wikia.tests.core;

namespace wikia.integration.tests.WikiArticleListTests
{
    [TestFixture]
    [Category(TestType.Integration)]
    public class AlphabeticalListTests
    {
        [TestCaseSource(typeof(WikiaTestData), nameof(WikiaTestData.ArticleListTestData))]
        public async Task Given_An_ArticleCategory_The_Response_Items_Collection_Should_Not_Be_Empty(string domainUrl, string category)
        {
            // Arrange
            var wikiaArticleList = new WikiArticleList(domainUrl, WikiaSettings.ApiVersion);

            // Act
            var result = await wikiaArticleList.AlphabeticalList(category);

            // Assert
            result.Items.Should().NotBeEmpty();
        }
    }
}