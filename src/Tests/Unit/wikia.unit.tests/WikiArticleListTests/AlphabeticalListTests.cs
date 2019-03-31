using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using wikia.Api;
using wikia.Configuration;
using wikia.tests.core;

namespace wikia.unit.tests.WikiArticleListTests
{
    [TestFixture]
    [Category(TestType.Unit)]
    public class AlphabeticalListTests
    {
        private IWikiArticleList _sut;
        private IWikiaHttpClient _wikiaHttpClient;
        private const string Url = "http://yugioh.fandom.com";

        [SetUp]
        public void Setup()
        {
            _wikiaHttpClient = Substitute.For<IWikiaHttpClient>();
            _sut = new WikiArticleList(Url, WikiaSettings.ApiVersion, _wikiaHttpClient);
        }

        [Test]
        public async Task Given_An_ArticleCategory_The_Response_Items_Collection_Should_Not_Be_Empty()
        {
            // Arrange
            const string category = "Card_Tips";
            _wikiaHttpClient.GetString(Arg.Any<string>(), Arg.Any<Dictionary<string, string>>()).Returns(@"{ ""items"": [ { ""id"": 30438, ""title"": ""\""A\"" Cell Breeding Device"", ""url"": ""/wiki/%22A%22_Cell_Breeding_Device"", ""ns"": 0 }, { ""id"": 239034, ""title"": ""\""A\"" Cell Culture Device"", ""url"": ""/wiki/%22A%22_Cell_Culture_Device"", ""ns"": 0 }, { ""id"": 239035, ""title"": ""\""A\"" Cell Dissemination Bomb"", ""url"": ""/wiki/%22A%22_Cell_Dissemination_Bomb"", ""ns"": 0 }, { ""id"": 48321, ""title"": ""\""A\"" Cell Incubator"", ""url"": ""/wiki/%22A%22_Cell_Incubator"", ""ns"": 0 }, { ""id"": 239033, ""title"": ""\""A\"" Cell Proliferation Device"", ""url"": ""/wiki/%22A%22_Cell_Proliferation_Device"", ""ns"": 0 }, { ""id"": 579181, ""title"": ""\""A\"" Cell Recombination Device"", ""url"": ""/wiki/%22A%22_Cell_Recombination_Device"", ""ns"": 0 }, { ""id"": 615528, ""title"": ""\""A\"" Cell Recomposition Device"", ""url"": ""/wiki/%22A%22_Cell_Recomposition_Device"", ""ns"": 0 }, { ""id"": 32484, ""title"": ""\""A\"" Cell Scatter Burst"", ""url"": ""/wiki/%22A%22_Cell_Scatter_Burst"", ""ns"": 0 }, { ""id"": 396513, ""title"": ""\""A Legendary Ocean\"""", ""url"": ""/wiki/%22A_Legendary_Ocean%22"", ""ns"": 0 }, { ""id"": 396487, ""title"": ""\""Backup Soldier\"""", ""url"": ""/wiki/%22Backup_Soldier%22"", ""ns"": 0 }, { ""id"": 396489, ""title"": ""\""Blade Knight\"""", ""url"": ""/wiki/%22Blade_Knight%22"", ""ns"": 0 }, { ""id"": 396547, ""title"": ""\""Bottomless Trap Hole\"""", ""url"": ""/wiki/%22Bottomless_Trap_Hole%22"", ""ns"": 0 }, { ""id"": 406226, ""title"": ""\""C\"""", ""url"": ""/wiki/%22C%22"", ""ns"": 0 }, { ""id"": 691243, ""title"": ""\""C\"" Ranger Shine Black"", ""url"": ""/wiki/%22C%22_Ranger_Shine_Black"", ""ns"": 0 }, { ""id"": 396370, ""title"": ""\""Call of the Haunted\"" + \""Jinzo\"""", ""url"": ""/wiki/%22Call_of_the_Haunted%22_%2B_%22Jinzo%22"", ""ns"": 0 }, { ""id"": 396481, ""title"": ""\""Ceasefire\"""", ""url"": ""/wiki/%22Ceasefire%22"", ""ns"": 0 }, { ""id"": 90720, ""title"": ""\""Command Knight\"""", ""url"": ""/wiki/%22Command_Knight%22"", ""ns"": 0 }, { ""id"": 397105, ""title"": ""\""Curse of Anubis\"""", ""url"": ""/wiki/%22Curse_of_Anubis%22"", ""ns"": 0 }, { ""id"": 397991, ""title"": ""\""Cyber Dragon\"" Fusion program"", ""url"": ""/wiki/%22Cyber_Dragon%22_Fusion_program"", ""ns"": 0 }, { ""id"": 396452, ""title"": ""\""Dark Hole\"""", ""url"": ""/wiki/%22Dark_Hole%22"", ""ns"": 0 }, { ""id"": 396993, ""title"": ""\""Dark Magician of Chaos\"""", ""url"": ""/wiki/%22Dark_Magician_of_Chaos%22"", ""ns"": 0 }, { ""id"": 396527, ""title"": ""\""Dark Necrofear\"""", ""url"": ""/wiki/%22Dark_Necrofear%22"", ""ns"": 0 }, { ""id"": 396588, ""title"": ""\""Destiny Board\"""", ""url"": ""/wiki/%22Destiny_Board%22"", ""ns"": 0 }, { ""id"": 397103, ""title"": ""\""Dimension Fusion\"""", ""url"": ""/wiki/%22Dimension_Fusion%22"", ""ns"": 0 }, { ""id"": 396416, ""title"": ""\""Dust Tornado\"""", ""url"": ""/wiki/%22Dust_Tornado%22"", ""ns"": 0 } ], ""basepath"": ""https://yugioh.fandom.com"", ""offset"": ""\""Elemental HERO Sparkman's\"" arsenal"" }");

            // Act
            var result = await _sut.AlphabeticalList(category);

            // Assert
            result.Items.Should().NotBeEmpty();
        }
    }
}