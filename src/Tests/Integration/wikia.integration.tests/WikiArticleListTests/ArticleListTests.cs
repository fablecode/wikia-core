using FluentAssertions;
using NUnit.Framework;
using System.Threading.Tasks;
using wikia.Api;
using wikia.Models.Article;
using wikia.tests.core;

namespace wikia.integration.tests.WikiArticleListTests
{
    [TestFixture]
    [Category(TestType.Integration)]
    public class ArticleListTests
    {
        [TestCaseSource(typeof(WikiaTestData), nameof(WikiaTestData.ArticleListTestData))]
        public async Task Given_A_DomainUrl_And_Category_The_Response_Items_Collection_Should_Not_Be_Empty(string domainUrl, string category)
        {
            // Arrange
            var wikiaArticleList = new WikiArticleList(domainUrl);

            // Act
            var result = await wikiaArticleList.AlphabeticalList(category);

            // Assert
            result.Items.Should().NotBeEmpty();
        }

        [Test]
        public async Task Given_An_AlphabeticalList_Request_Offset_Should_Begin_Page_Prefix()
        {
            // Arrange
            const string expected = "page|";
            const string category = "Card_Tips";
            const string domainUrl = "https://yugioh.fandom.com";
            var parameters = new ArticleListRequestParameters(category);
            var wikiaArticleList = new WikiArticleList(domainUrl);

            // Act
            var result = await wikiaArticleList.AlphabeticalList(parameters);

            // Assert
            result.Offset.Should().StartWith(expected);
        }
    }
}