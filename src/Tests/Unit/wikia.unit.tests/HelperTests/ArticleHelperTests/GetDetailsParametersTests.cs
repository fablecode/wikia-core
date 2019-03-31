using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using wikia.Helper;
using wikia.Models.Article.Details;
using wikia.tests.core;

namespace wikia.unit.tests.HelperTests.ArticleHelperTests
{
    [TestFixture]
    [Category(TestType.Unit)]
    public class GetDetailsParametersTests
    {
        [Test]
        public void Given_An_ArticleDetailsRequestParameters_If_Titles_Are_Specified_Dictionary_Should_Contain_Titles_Key()
        {
            // Arrange
            const string expected = "titles";
            const int ids = 50;
            var titles = new List<string> {"Solemn Wishes"};

            // Act
            var result = ArticleHelper.GetDetailsParameters(new ArticleDetailsRequestParameters(ids) {Titles = titles});

            // Assert
            result.Should().ContainKey(expected);
        }
    }
}