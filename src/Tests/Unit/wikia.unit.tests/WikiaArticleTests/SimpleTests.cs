using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using wikia.Api;
using wikia.Configuration;
using wikia.Models.Article.Simple;
using wikia.tests.core;

namespace wikia.unit.tests.WikiaArticleTests
{
    [TestFixture]
    [Category(TestType.Unit)]
    public class SimpleTests
    {
        private WikiArticle _sut;
        private IWikiaHttpClient _wikiaHttpClient;
        private const string Url = "http://naruto.wikia.com";

        [SetUp]
        public void Setup()
        {
            _wikiaHttpClient = Substitute.For<IWikiaHttpClient>();
            _sut = new WikiArticle(Url, WikiaSettings.ApiVersion, _wikiaHttpClient);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-4958)]
        public void Given_An_Invalid_ArticleId_Should_Throw_ArgumentOutOfRangeException(long articleId)
        {
            // Arrange
            // Act
            Func<Task<ContentResult>> act = () => _sut.Simple(articleId);

            // Assert
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Test]
        public async Task Given_A_Valid_ArticleId_Should_Return_ContentResult()
        {
            // Arrange
            const long articleId = 2342;

            _wikiaHttpClient.GetString(Arg.Any<string>(), Arg.Any<Dictionary<string, string>>()).Returns(@"{ ""sections"": [ { ""title"": ""Solemn Wishes"", ""level"": 1, ""content"": [], ""images"": [] } ] }");

            // Act
            var result = await _sut.Simple(articleId);

            // Assert
            result.Should().NotBeNull();
        }
    }
}