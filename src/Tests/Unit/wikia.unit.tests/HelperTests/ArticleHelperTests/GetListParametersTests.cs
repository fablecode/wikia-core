using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using wikia.Helper;
using wikia.Models.Article;
using wikia.tests.core;

namespace wikia.unit.tests.HelperTests.ArticleHelperTests
{
    //[TestFixture]
    //[Category(TestType.Unit)]
    //public class GetListParametersTests
    //{
    //    [Test]
    //    public void Given_An_NewArticleRequestParameters_If_Expanded_Value_Is_True_Dictionary_Should_Contain_Expand_Key()
    //    {
    //        // Arrange
    //        const string expected = "expand";
    //        var namespaces = new HashSet<string>{ "Card Tips", "Card Trivia" };

    //        // Act
    //        var result = ArticleHelper.GetListParameters(new ArticleListRequestParameters(), true);

    //        // Assert
    //        result.Should().ContainKey(expected);
    //    }


    //    [Test]
    //    public void Given_An_NewArticleRequestParameters_If_Category_Has_Value_Dictionary_Should_Contain_Category_Key()
    //    {
    //        // Arrange
    //        const string expected = "category";
    //        const string category = "Card_Tips";

    //        // Act
    //        var result = ArticleHelper.GetListParameters(new ArticleListRequestParameters{ Category = category });

    //        // Assert
    //        result.Should().ContainKey(expected);
    //    }

    //    [Test]
    //    public void Given_An_NewArticleRequestParameters_If_Namespaces_Are_Specified_Dictionary_Should_Contain_Namespaces_Key()
    //    {
    //        // Arrange
    //        const string expected = "namespaces";
    //        var namespaces = new HashSet<string>{ "Card Tips", "Card Trivia" };

    //        // Act
    //        var result = ArticleHelper.GetListParameters(new ArticleListRequestParameters{ Namespaces = namespaces });

    //        // Assert
    //        result.Should().ContainKey(expected);
    //    }

    //    [Test]
    //    public void Given_An_NewArticleRequestParameters_If_Offset_Has_Value_Dictionary_Should_Contain_Offset_Key()
    //    {
    //        // Arrange
    //        const string expected = "offset";
    //        const string offset = "page|414d415a4f4e455353205350454c4c434153544552|93782";

    //        // Act
    //        var result = ArticleHelper.GetListParameters(new ArticleListRequestParameters { Offset = offset });

    //        // Assert
    //        result.Should().ContainKey(expected);
    //    }
    //}
}