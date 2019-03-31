using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using wikia.Helper;
using wikia.Models.Article.NewArticles;
using wikia.tests.core;

namespace wikia.unit.tests.HelperTests.ArticleHelperTests
{
    [TestFixture]
    [Category(TestType.Unit)]
    public class GetNewArticleParametersTests
    {
        [Test]
        public void Given_A_NewArticleRequestParameters_If_Namespaces_Are_Specified_Dictionary_Should_Contain_Namespace_Key()
        {
            // Arrange
            const string expected = "namespaces";
            var namespaces = new HashSet<string> { "Card Tips", "Card Trivia" };

            // Act
            var result = ArticleHelper.GetNewArticleParameters(new NewArticleRequestParameters { Namespaces = namespaces });

            // Assert
            result.Should().ContainKey(expected);
        }
    }
}