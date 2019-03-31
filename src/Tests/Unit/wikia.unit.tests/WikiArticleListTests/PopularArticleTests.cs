using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using wikia.Api;
using wikia.Configuration;
using wikia.Models.Article.Popular;
using wikia.tests.core;

namespace wikia.unit.tests.WikiArticleListTests
{
    [TestFixture]
    [Category(TestType.Unit)]
    public class PopularArticleTests
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
        public void Given_A_Null_PopularListArticleResultSet_Should_Throw_ArgumentNullException()
        {
            // Arrange

            // Act
            Func<Task<PopularListArticleResultSet>> act = () => _sut.PopularArticleSimple(null);

            // Assert
            act.Should().Throw<ArgumentNullException>();
        }

        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(11)]
        public void Given_An_PopularArticleRequestParameters_If_Limit_Fails_Validation_Should_Throw_ArgumentOutOfRangeException(int limit)
        {
            // Arrange

            // Act
            Func<Task<PopularExpandedArticleResultSet>> act = () => _sut.PopularArticleDetail(new PopularArticleRequestParameters { Limit = limit });

            // Assert
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Test]
        public async Task Given_A_PopularArticleRequestParameters_Should_Return_Popular_Articles()
        {
            // Arrange
            _wikiaHttpClient.GetString(Arg.Any<string>(), Arg.Any<Dictionary<string, string>>()).Returns(@"{ ""items"": [ { ""id"": 79895, ""title"": ""Stardust Dragon"", ""url"": ""/wiki/Stardust_Dragon"" } ], ""basepath"": ""https://yugioh.fandom.com"" }");

            // Act
            var result = await _sut.PopularArticle<PopularListArticleResultSet>(new PopularArticleRequestParameters(), false);

            // Assert
            result.Items.Should().NotBeEmpty();
        }

    }
}