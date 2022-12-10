using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;
using wikia.Api;
using wikia.Models.Article.Details;
using wikia.tests.core;

namespace wikia.unit.tests.WikiaArticleTests
{
    [TestFixture]
    [Category(TestType.Unit)]
    public class DetailTests
    {
        private WikiArticle _sut;
        private IWikiArticleApi _wikiArticleApi;

        [SetUp]
        public void Setup()
        {
            _wikiArticleApi = Substitute.For<IWikiArticleApi>();
            _sut = new WikiArticle(_wikiArticleApi);
        }

        [Test]
        public async Task Given_A_Null_ArticleDetailsRequestParameters_Should_Throw_ArgumentNullException()
        {
            // Arrange

            // Act
            var act = () => _sut.Details((ArticleDetailsRequestParameters)null);

            // Assert
            await act.Should().ThrowAsync<ArgumentNullException>();
        }

        [Test]
        public async Task Given_Article_Ids_Should_Invoke_Details_Method_Once()
        {
            // Arrange
            const int expected = 1;
            var articleIds = new[] { 50, 60, 70 };
            _wikiArticleApi
                .Details(Arg.Any<ArticleDetailsRequestParameters>())
                .Returns(new ExpandedArticleResultSet());

            // Act
            await _sut.Details(articleIds);

            // Assert
            await _wikiArticleApi.Received(expected).Details(Arg.Is<ArticleDetailsRequestParameters>(p => p.Ids.SequenceEqual(articleIds)));
        }
    }
}