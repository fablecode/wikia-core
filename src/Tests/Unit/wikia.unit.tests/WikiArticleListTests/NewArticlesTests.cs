using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using wikia.Api;
using wikia.Configuration;
using wikia.Models.Article.NewArticles;
using wikia.tests.core;

namespace wikia.unit.tests.WikiArticleListTests
{
    [TestFixture]
    [Category(TestType.Unit)]
    public class NewArticlesTests
    {
        private IWikiArticleList _sut;
        private IWikiaHttpClient _wikiaHttpClient;
        private const string Url = "http://yugioh.fandom.com";

        [SetUp]
        public void Setup()
        {
            _wikiaHttpClient = Substitute.For<IWikiaHttpClient>();
            _sut = new WikiArticleList(Url, WikiaSettings.ApiVersion, _wikiaHttpClient);
        }

        [Test]
        public void Given_A_Null_NewArticleResultSet_Should_Throw_ArgumentNullException()
        {
            // Arrange

            // Act
            Func<Task<NewArticleResultSet>> act = () => _sut.NewArticles(null);

            // Assert
            act.Should().Throw<ArgumentNullException>();
        }

        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(101)]
        public void Given_An_NewArticleResultSet_If_Limit_Fails_Validation_Should_Throw_ArgumentOutOfRangeException(int limit)
        {
            // Arrange

            // Act
            Func<Task<NewArticleResultSet>> act = () => _sut.NewArticles(new NewArticleRequestParameters { Limit = limit });

            // Assert
            act.Should().Throw<ArgumentOutOfRangeException>();
        }


        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(100)]
        public void Given_An_NewArticleResultSet_If_MinArticleQuality_Fails_Validation_Should_Throw_ArgumentOutOfRangeException(int minArticleQuality)
        {
            // Arrange

            // Act
            Func<Task<NewArticleResultSet>> act = () => _sut.NewArticles(new NewArticleRequestParameters { MinArticleQuality = minArticleQuality });

            // Assert
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Test]
        public async Task Given_An_NewArticleResultSet_Should_Return_New_Articles()
        {
            // Arrange
            _wikiaHttpClient.GetString(Arg.Any<string>(), Arg.Any<Dictionary<string, string>>()).Returns(@"{ ""items"": [ { ""id"": 704382, ""ns"": 0, ""title"": ""Gouki Cage Match"", ""abstract"": ""Gouki Cage Match 剛（ごう）鬼（き）死闘（デスマッチ） English Gouki Cage Match Japanese (kana) ごうきデスマッチ Check translation Japanese (base) 剛鬼死闘 Check translation Japanese (rōmaji) Gōki Desumacchi..."", ""quality"": 81, ""url"": ""/wiki/Gouki_Cage_Match"", ""creator"": { ""avatar"": null, ""name"": null }, ""creation_date"": null, ""thumbnail"": null, ""original_dimensions"": null } ], ""basepath"": ""https://yugioh.fandom.com"" }");

            // Act
            var result = await _sut.NewArticles();

            // Assert
            result.Items.Should().NotBeEmpty();
        }
    }
}