using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using wikia.Api;
using wikia.Configuration;
using wikia.Models.Article.Details;
using wikia.tests.core;

namespace wikia.unit.tests.WikiaArticleTests
{
    [TestFixture]
    [Category(TestType.Unit)]
    public class DetailTests
    {
        private WikiArticle _sut;
        private IWikiaHttpClient _wikiaHttpClient;
        private const string Url = "http://yugioh.fandom.com";

        [SetUp]
        public void Setup()
        {
            _wikiaHttpClient = Substitute.For<IWikiaHttpClient>();
            _sut = new WikiArticle(Url, WikiaSettings.ApiVersion, _wikiaHttpClient);
        }

        [Test]
        public void Given_A_Null_ArticleDetailsRequestParameters_Should_Throw_ArgumentNullException()
        {
            // Arrange

            // Act
            Func<Task<ExpandedArticleResultSet>> act = () => _sut.Details((ArticleDetailsRequestParameters)null);

            // Assert
            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public async Task Given_An_ArticleDetailsRequestParameters_The_Response_Items_Collection_Should_Contain_Id_Key()
        {
            // Arrange
            const string expected = "50";

            const int ids = 50;
            _wikiaHttpClient.GetString(Arg.Any<string>(), Arg.Any<Dictionary<string, string>>()).Returns(@"{ ""items"": { ""50"": { ""id"": 50, ""title"": ""Solemn Wishes"", ""ns"": 0, ""url"": ""/wiki/Solemn_Wishes"", ""revision"": { ""id"": 3917607, ""user"": ""Zustel"", ""user_id"": 27521587, ""timestamp"": ""1515150643"" }, ""type"": ""article"", ""abstract"": ""Solemn Wishes 神（かみ）の恵（めぐ）み English Solemn Wishes Chinese 神之恩惠 Check translation French Vœux..."", ""thumbnail"": ""https://vignette.wikia.nocookie.net/yugioh/images/d/d7/SolemnWishes-DB1-EN-C-UE.png/revision/latest/window-crop/width/200/x-offset/0/y-offset/0/window-width/558/window-height/558?cb=20171030173518"", ""original_dimensions"": { ""width"": 558, ""height"": 814 } } }, ""basepath"": ""https://yugioh.fandom.com"" }");

            // Act
            var result = await _sut.Details(ids);

            // Assert
            result.Items.Should().ContainKey(expected);
        }
    }
}