using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using wikia.Api;
using wikia.Configuration;
using wikia.tests.core;

namespace wikia.integration.tests.WikiArticleListTests;

[TestFixture]
[Category(TestType.Integration)]
public class NewArticlesTests
{
    [Test]
    public async Task Given_An_NewArticleResultSet_Should_Return_New_Articles()
    {
        // Arrange
        const string domainUrl = "http://yugioh.fandom.com";
        var wikiaArticleList = new WikiArticleList(domainUrl);

        // Act
        var result = await wikiaArticleList.NewArticles();

        // Assert
        result.Items.Should().NotBeEmpty();
    }
}