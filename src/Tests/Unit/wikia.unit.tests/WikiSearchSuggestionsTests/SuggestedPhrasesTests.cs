using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using wikia.Api;
using wikia.Models.SearchSuggestions;
using wikia.tests.core;

namespace wikia.unit.tests.WikiSearchSuggestionsTests
{
    [TestFixture]
    [Category(TestType.Unit)]
    public class SuggestedPhrasesTests
    {
        private WikiSearchSuggestions _sut;
        private IWikiSearchSuggestionsApi _wikiSearchSuggestionsApi;

        [SetUp]
        public void Setup()
        {
            _wikiSearchSuggestionsApi = Substitute.For<IWikiSearchSuggestionsApi>();
            _sut = new WikiSearchSuggestions(_wikiSearchSuggestionsApi);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public async Task Given_A_Invalid_Query_Should_Throw_ArgumentException(string query)
        {
            // Arrange
            // Act
            var act = () => _sut.SuggestedPhrases(query);

            // Assert
            await act.Should().ThrowAsync<ArgumentException>();
        }

        [Test]
        public async Task Given_A_Query_Should_Invoke_SuggestedPhrases_Method_Once()
        {
            // Arrange
            const string query = "jinzo";

            _wikiSearchSuggestionsApi
                .SuggestedPhrases(query)
                .Returns(new SearchSuggestionsPhrases());

            // Act
            await _sut.SuggestedPhrases(query);

            // Assert
            await _wikiSearchSuggestionsApi.Received(1).SuggestedPhrases(Arg.Is(query));
        }
    }
}