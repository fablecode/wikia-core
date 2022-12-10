using NSubstitute;
using NUnit.Framework;
using System.Threading.Tasks;
using wikia.Api;
using wikia.tests.core;

namespace wikia.unit.tests.WikiMercuryTests
{
    [TestFixture]
    [Category(TestType.Unit)]
    public class WikiMercuryTests
    {
        private WikiMercury _sut;
        private IWikiMercuryApi _wikiMercuryApi;

        [SetUp]
        public void Setup()
        {
            _wikiMercuryApi = Substitute.For<IWikiMercuryApi>();
            _sut = new WikiMercury(_wikiMercuryApi);
        }

        [Test]
        public async Task Should_Invoke_WikiVariables_Api_Method_Once()
        {
            // Arrange

            // Act
            await _sut.WikiVariables();

            // Assert
            await _wikiMercuryApi.Received(1).WikiVariables();
        }
    }
}