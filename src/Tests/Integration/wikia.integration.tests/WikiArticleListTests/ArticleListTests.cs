using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using wikia.Api;
using wikia.Configuration;
using wikia.Models.Article;
using wikia.Models.Article.AlphabeticalList;
using wikia.tests.core;

namespace wikia.integration.tests.WikiArticleListTests
{
    [TestFixture]
    [Category(TestType.Integration)]
    public class ArticleListTests
    {
        [TestCaseSource(typeof(WikiaTestData), nameof(WikiaTestData.ArticleListTestData))]
        public async Task Given_An_ArticleListRequestParameters_The_Response_Items_Collection_Should_Not_Be_Empty(string domainUrl, string category)
        {
            // Arrange
            var wikiaArticleList = new WikiArticleList(domainUrl, WikiaSettings.ApiVersion);

            // Act
            var result = await wikiaArticleList.ArticleList<UnexpandedListArticleResultSet>(new ArticleListRequestParameters { Category = category }, false);

            // Assert
            result.Items.Should().NotBeEmpty();
        }
    }

    [TestFixture]
    [Category(TestType.Integration)]
    public class NewArticlesTests
    {
        [Test]
        public async Task Given_An_NewArticleResultSet_Should_Return_New_Articles()
        {
            // Arrange
            const string domainUrl = "http://yugioh.fandom.com";
            var wikiaArticleList = new WikiArticleList(domainUrl, WikiaSettings.ApiVersion);

            // Act
            var result = await wikiaArticleList.NewArticles();

            // Assert
            result.Items.Should().NotBeEmpty();
        }
    }
}