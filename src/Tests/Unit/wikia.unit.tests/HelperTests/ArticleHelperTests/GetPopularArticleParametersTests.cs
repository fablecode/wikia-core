using FluentAssertions;
using NUnit.Framework;
using wikia.Helper;
using wikia.Models.Article.Popular;
using wikia.tests.core;

namespace wikia.unit.tests.HelperTests.ArticleHelperTests
{
    [TestFixture]
    [Category(TestType.Unit)]
    public class GetPopularArticleParametersTests
    {
        [Test]
        public void Given_A_PopularArticleRequestParameters_If_Expanded_Value_Is_True_Dictionary_Should_Contain_Expand_Key()
        {
            // Arrange
            const string expected = "expand";

            // Act
            var result = ArticleHelper.GetPopularArticleParameters(new PopularArticleRequestParameters(), true);

            // Assert
            result.Should().ContainKey(expected);
        }

        [Test]
        public void Given_A_PopularArticleRequestParameters_If_BaseArticleId_Has_A_Value_Dictionary_Should_Contain_BaseArticleId_Key()
        {
            // Arrange
            const string expected = "basearticleid";

            // Act
            var result = ArticleHelper.GetPopularArticleParameters(new PopularArticleRequestParameters{ BaseArticleId = 50});

            // Assert
            result.Should().ContainKey(expected);
        }
    }
}