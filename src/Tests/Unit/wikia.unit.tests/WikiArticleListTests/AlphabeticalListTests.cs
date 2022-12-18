using NSubstitute;
using NUnit.Framework;
using System.Threading.Tasks;
using wikia.Api;
using wikia.Models.Article;
using wikia.Models.Article.AlphabeticalList;
using wikia.Services;
using wikia.tests.core;

namespace wikia.unit.tests.WikiArticleListTests
{
    [TestFixture]
    [Category(TestType.Unit)]
    public class AlphabeticalListTests
    {
        private IWikiArticleList _sut;
        private IWikiArticleListApi _wikiArticleListApi;

        [SetUp]
        public void Setup()
        {
            _wikiArticleListApi = Substitute.For<IWikiArticleListApi>();
            _sut = new WikiArticleList(_wikiArticleListApi);
        }

        [Test]
        public async Task Given_An_Article_Category_Should_Invoke_AlphabeticalList_Api_Method_Once()
        {
            // Arrange
            const int expected = 1;
            const string category = "Card_Tips";
            var articleListRequestParameters = new ArticleListRequestParameters(category);
            _wikiArticleListApi
                .AlphabeticalList(articleListRequestParameters)
                .Returns(new UnexpandedListArticleResultSet());

            // Act
            await _sut.AlphabeticalList(category);

            // Assert
            await _wikiArticleListApi.Received(expected).AlphabeticalList(Arg.Is(articleListRequestParameters));
        }
    }
}