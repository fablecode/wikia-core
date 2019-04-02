using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using wikia.Api;
using wikia.Configuration;
using wikia.Models.RelatedPages;
using wikia.tests.core;

namespace wikia.unit.tests.WikiRelatedPagesTests
{
    [TestFixture]
    [Category(TestType.Unit)]
    public class ArticlesTests
    {
        private WikiRelatedPages _sut;
        private IWikiaHttpClient _wikiaHttpClient;
        private const string Url = "http://yugioh.fandom.com";

        [SetUp]
        public void Setup()
        {
            _wikiaHttpClient = Substitute.For<IWikiaHttpClient>();
            _sut = new WikiRelatedPages(Url, WikiaSettings.ApiVersion, _wikiaHttpClient);
        }

        [Test]
        public void Given_A_Null_RelatedArticlesRequestParameters_Should_ArgumentNullException()
        {
            // Arrange
            // Act
            Func<Task<RelatedPages>> act = () => _sut.Articles((RelatedArticlesRequestParameters)null);

            // Assert
            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void Given_A_Null_Or_Empty_Ids_List_RelatedArticlesRequestParameters_Should_ArgumentException()
        {
            // Arrange
            // Act
            Func<Task<RelatedPages>> act = () => _sut.Articles(new RelatedArticlesRequestParameters());

            // Assert
            act.Should().Throw<ArgumentException>();
        }

        [Test]
        public async Task Given_Ids_List_RelatedArticlesRequestParameters_Should_()
        {
            // Arrange
            _wikiaHttpClient.GetString(Arg.Any<string>(), Arg.Any<Dictionary<string, string>>()).Returns(@"{ ""items"": { ""50"": [ { ""url"": ""/wiki/Super_Junior_Confrontation"", ""title"": ""Super Junior Confrontation"", ""id"": 23338, ""imgUrl"": ""https://vignette.wikia.nocookie.net/yugioh/images/2/21/SuperJuniorConfrontation-DR04-NA-C-UE.png/revision/latest/window-crop/width/200/x-offset/0/y-offset/58/window-width/400/window-height/200?cb=20080530031342"", ""imgOriginalDimensions"": { ""width"": ""400"", ""height"": ""580"" }, ""text"": ""Super Junior Confrontation スーパージュニア対（たい）決（けつ）！ English Super Junior Confrontation French..."" }, { ""url"": ""/wiki/Topologic_Trisbaena"", ""title"": ""Topologic Trisbaena"", ""id"": 681182, ""imgUrl"": ""https://vignette.wikia.nocookie.net/yugioh/images/2/2b/TopologicTrisbaena-FLOD-EN-ScR-1E.png/revision/latest/window-crop/width/200/x-offset/0/y-offset/70/window-width/479/window-height/240?cb=20180504165822"", ""imgOriginalDimensions"": { ""width"": ""479"", ""height"": ""700"" }, ""text"": ""Check translation Check translation"" }, { ""url"": ""/wiki/Witchcrafter_Draping"", ""title"": ""Witchcrafter Draping"", ""id"": 702109, ""imgUrl"": ""https://vignette.wikia.nocookie.net/yugioh/images/4/47/WitchcrafterDraping-INCH-EN-1E-OP.png/revision/latest/window-crop/width/200/x-offset/0/y-offset/66/window-width/450/window-height/225?cb=20190315154155"", ""imgOriginalDimensions"": { ""width"": ""450"", ""height"": ""656"" }, ""text"": ""The English lore given is not official. Check translation"" } ] }, ""basepath"": ""https://yugioh.fandom.com"" }");

            // Act
            var result = await _sut.Articles(50);

            // Assert
            result.Items.Should().NotBeEmpty();
        }
    }
}