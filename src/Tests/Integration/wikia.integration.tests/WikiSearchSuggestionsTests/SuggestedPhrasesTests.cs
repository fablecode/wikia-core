using System;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using wikia.Api;
using wikia.Models.SearchSuggestions;
using wikia.tests.core;

namespace wikia.integration.tests.WikiSearchSuggestionsTests
{
    [TestFixture]
    [Category(TestType.Unit)]
    public class SuggestedPhrasesTests
    {
        private WikiSearchSuggestions _sut;
        private IWikiaHttpClient _wikiaHttpClient;
        private const string Url = "http://yugioh.fandom.com";

        [SetUp]
        public void Setup()
        {
            _sut = new WikiSearchSuggestions(Url);
        }

        [Test]
        public void Given_A_Null_Query_Should_ArgumentException()
        {
            // Arrange
            // Act
            Func<Task<SearchSuggestionsPhrases>> act = () => _sut.SuggestedPhrases(null);

            // Assert
            act.Should().Throw<ArgumentException>();
        }

        [Test]
        public async Task Given_A_Query_Should_Execute_Successfully()
        {
            // Arrange
            const string query = "jinzo";

            // Act
            var result = await _sut.SuggestedPhrases(query);

            // Assert
            result.Items.Should().NotBeEmpty();
        }
    }
}