using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using System.Threading.Tasks;
using wikia.Api;
using wikia.Configuration;
using wikia.tests.core;

namespace wikia.unit.tests.WikiMercuryTests
{
    [TestFixture]
    [Category(TestType.Unit)]
    public class WikiMercuryTests
    {
        private WikiMercury _sut;
        private IWikiaHttpClient _wikiaHttpClient;
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