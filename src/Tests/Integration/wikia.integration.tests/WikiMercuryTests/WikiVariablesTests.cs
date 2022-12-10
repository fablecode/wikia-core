using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using wikia.Api;
using wikia.Services;
using wikia.tests.core;

namespace wikia.integration.tests.WikiMercuryTests
{
    [TestFixture]
    [Category(TestType.Unit)]
    public class WikiMercuryTests
    {
        private WikiMercury _sut;
        private const string Url = "http://yugioh.fandom.com";

        [SetUp]
        public void Setup()
        {
            _sut = new WikiMercury(Url);
        }


        [Test]
        public async Task If_Invoked_Should_Return_Wikia_Variables()
        {
            // Arrange

            // Act
            var result = await _sut.WikiVariables();

            // Assert
            result.Should().NotBeNull();
        }
    }
}