using System.Threading.Tasks;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using wikia.Api;
using wikia.Configuration;
using wikia.tests.core;

namespace wikia.unit.tests.WikiNavigationTests
{
    [TestFixture]
    [Category(TestType.Unit)]
    public class WikiNavigationTests
    {
        private WikiNavigation _sut;
        private IWikiaHttpClient _wikiaHttpClient;
        private const string Url = "http://yugioh.fandom.com";

        [SetUp]
        public void Setup()
        {
            _sut = new WikiNavigation(Url);
        }


        [Test]
        public async Task If_Invoked_Should_Return_Wikia_NavigationLinks()
        {
            // Arrange

            // Act
            var result = await _sut.NavigationLinks();

            // Assert
            result.Should().NotBeNull();
        }


        [Test]
        public async Task Should_Invoke_GetString_Method_Once()
        {
            // Arrange
            _wikiaHttpClient.GetString(Arg.Any<string>()).Returns(@"{ ""navigation"": { ""wikia"": [ { ""text"": ""On the Wiki"", ""href"": ""#"", ""children"": [ { ""text"": ""Wiki Activity"", ""href"": ""/wiki/Special:WikiActivity"" }, { ""text"": ""Page"", ""href"": ""/wiki/Special:Random"" }, { ""text"": ""Videos"", ""href"": ""/wiki/Special:Videos"" }, { ""text"": ""Photos"", ""href"": ""/wiki/Special:NewFiles"" }, { ""text"": ""Discussions"", ""href"": ""/d/f"" } ] } ], ""wiki"": [ { ""text"": ""Top Content"", ""href"": ""#"", ""children"": [ { ""text"": ""Most Visited"", ""href"": ""#"", ""children"": [ { ""text"": ""Duel Power"", ""href"": ""/wiki/Duel_Power"" }, { ""text"": ""Rising Rampage"", ""href"": ""/wiki/Rising_Rampage"" }, { ""text"": ""Dark Neostorm"", ""href"": ""/wiki/Dark_Neostorm"" }, { ""text"": ""Yu-Gi-Oh! VRAINS - Episode 095"", ""href"": ""/wiki/Yu-Gi-Oh!_VRAINS_-_Episode_095"" }, { ""text"": ""Arcana Force"", ""href"": ""/wiki/Arcana_Force"" }, { ""text"": ""The Infinity Chasers"", ""href"": ""/wiki/The_Infinity_Chasers"" }, { ""text"": ""Structure Deck R: Lord of Magician"", ""href"": ""/wiki/Structure_Deck_R:_Lord_of_Magician"" } ] }, { ""text"": ""Newly Changed"", ""href"": ""#"", ""children"": [ { ""text"": ""Divine Dragon Ragnarok"", ""href"": ""/wiki/Divine_Dragon_Ragnarok"" }, { ""text"": ""Armor Exe"", ""href"": ""/wiki/Armor_Exe"" }, { ""text"": ""Ancient Sorcerer"", ""href"": ""/wiki/Ancient_Sorcerer"" }, { ""text"": ""Amores of Prophecy"", ""href"": ""/wiki/Amores_of_Prophecy"" }, { ""text"": ""Millennium-Eyes Illusionist"", ""href"": ""/wiki/Millennium-Eyes_Illusionist"" }, { ""text"": ""Illusionist Faceless Magician"", ""href"": ""/wiki/Illusionist_Faceless_Magician"" }, { ""text"": ""LVP1-JP036"", ""href"": ""/wiki/LVP1-JP036"" } ] }, { ""text"": ""Random"", ""href"": ""/wiki/Special:Random"", ""children"": [ { ""text"": ""Random Page"", ""href"": ""/wiki/Special:Random"" }, { ""text"": ""Gallery"", ""href"": ""/wiki/Special:Random/Card_Gallery"" }, { ""text"": ""Rulings"", ""href"": ""/wiki/Special:Random/Card_Rulings"" }, { ""text"": ""Errata"", ""href"": ""/wiki/Special:Random/Card_Errata"" }, { ""text"": ""Tips"", ""href"": ""/wiki/Special:Random/Card_Tips"" }, { ""text"": ""Appearances‎"", ""href"": ""/wiki/Special:Random/Card_Appearances"" }, { ""text"": ""Trivia"", ""href"": ""/wiki/Special:Random/Card_Trivia"" } ] } ] }, { ""text"": ""Characters"", ""href"": ""/wiki/Category:Characters"", ""children"": [ { ""text"": ""VRAINS"", ""href"": ""/wiki/Category:Yu-Gi-Oh!_VRAINS_characters"", ""children"": [ { ""text"": ""Anime"", ""href"": ""/wiki/Portal:Yu-Gi-Oh!_VRAINS_anime_characters"" } ] }, { ""text"": ""ARC-V"", ""href"": ""/wiki/Category:Yu-Gi-Oh!_ARC-V_characters"", ""children"": [ { ""text"": ""Anime"", ""href"": ""/wiki/Portal:Yu-Gi-Oh!_ARC-V_anime_characters"" }, { ""text"": ""Manga"", ""href"": ""/wiki/Portal:Yu-Gi-Oh!_ARC-V_manga_characters"" } ] }, { ""text"": ""ZEXAL"", ""href"": ""/wiki/Category:Yu-Gi-Oh!_ZEXAL_characters"", ""children"": [ { ""text"": ""Anime"", ""href"": ""/wiki/Portal:Yu-Gi-Oh!_ZEXAL_anime_characters"" }, { ""text"": ""Manga"", ""href"": ""/wiki/Portal:Yu-Gi-Oh!_ZEXAL_manga_characters"" }, { ""text"": ""D Team"", ""href"": ""/wiki/Portal:Yu-Gi-Oh!_D_Team_ZEXAL_characters"" } ] }, { ""text"": ""5D's"", ""href"": ""/wiki/Category:Yu-Gi-Oh!_5D%27s_characters"", ""children"": [ { ""text"": ""Anime"", ""href"": ""/wiki/Portal:Yu-Gi-Oh!_5D%27s_anime_characters"" }, { ""text"": ""Manga"", ""href"": ""/wiki/Portal:Yu-Gi-Oh!_5D%27s_manga_characters"" } ] }, { ""text"": ""GX"", ""href"": ""/wiki/Category:Yu-Gi-Oh!_GX_characters"", ""children"": [ { ""text"": ""Anime"", ""href"": ""/wiki/Portal:Yu-Gi-Oh!_GX_anime_characters"" }, { ""text"": ""Manga"", ""href"": ""/wiki/Portal:Yu-Gi-Oh!_GX_manga_characters"" } ] }, { ""text"": ""Yu-Gi-Oh!"", ""href"": ""/wiki/Category:Yu-Gi-Oh!_characters"", ""children"": [ { ""text"": ""Second anime"", ""href"": ""/wiki/Portal:Yu-Gi-Oh!_anime_characters"" }, { ""text"": ""First anime"", ""href"": ""/wiki/Portal:Yu-Gi-Oh!_first_series_anime_characters"" }, { ""text"": ""Manga"", ""href"": ""/wiki/Portal:Yu-Gi-Oh!_manga_characters"" } ] } ] }, { ""text"": ""Card Gallery"", ""href"": ""/wiki/Category:Card_Gallery"", ""children"": [ { ""text"": ""Sets by language"", ""href"": ""/wiki/Category:Set_Card_Galleries"", ""children"": [ { ""text"": ""Japanese Set Card Gallery"", ""href"": ""/wiki/Category:Japanese_Set_Card_Galleries"" }, { ""text"": ""English Set Card Gallery"", ""href"": ""/wiki/Category:English_Set_Card_Galleries"" }, { ""text"": ""French Set Card Gallery"", ""href"": ""/wiki/Category:French_Set_Card_Galleries"" }, { ""text"": ""German Set Card Gallery"", ""href"": ""/wiki/Category:German_Set_Card_Galleries"" }, { ""text"": ""Italian Set Card Gallery"", ""href"": ""/wiki/Category:Italian_Set_Card_Galleries"" }, { ""text"": ""Portuguese Set Card Gallery"", ""href"": ""/wiki/Category:Portuguese_Set_Card_Galleries"" }, { ""text"": ""Spanish Set Card Gallery"", ""href"": ""/wiki/Category:Spanish_Set_Card_Galleries"" }, { ""text"": ""Korean Set Card Gallery"", ""href"": ""/wiki/Category:Korean_Set_Card_Galleries"" } ] }, { ""text"": ""Sets by type"", ""href"": ""/wiki/Category:Set_Card_Galleries"", ""children"": [ { ""text"": ""Unlimited Edition Set Card Gallery"", ""href"": ""/wiki/Category:Unlimited_Edition_Set_Card_Galleries"" }, { ""text"": ""1st Edition Set Card Gallery"", ""href"": ""/wiki/Category:1st_Edition_Set_Card_Galleries"" }, { ""text"": ""Limited Edition Set Card Gallery"", ""href"": ""/wiki/Category:Limited_Edition_Set_Card_Galleries"" }, { ""text"": ""Yu-Gi-Oh! GX Chapter Card Gallery"", ""href"": ""/wiki/Category:Yu-Gi-Oh!_GX_Chapter_Card_Galleries"" }, { ""text"": ""Yu-Gi-Oh! 5D's Episode Card Gallery"", ""href"": ""/wiki/Category:Yu-Gi-Oh!_5D%27s_Episode_Card_Galleries"" }, { ""text"": ""Yu-Gi-Oh! ZEXAL Episode Card Gallery"", ""href"": ""/wiki/Category:Yu-Gi-Oh!_ZEXAL_Episode_Card_Galleries"" }, { ""text"": ""Yu-Gi-Oh! ARC-V Episode Card Gallery"", ""href"": ""/wiki/Category:Yu-Gi-Oh!_ARC-V_Episode_Card_Galleries"" } ] } ] }, { ""text"": ""Community"", ""href"": ""#"", ""children"": [ { ""text"": ""Current Events"", ""href"": ""/wiki/Yu-Gi-Oh!:Current_events"" }, { ""text"": ""Policies"", ""href"": ""/wiki/Category:Policy"" }, { ""text"": ""Forum"", ""href"": ""/wiki/Forum:Index"", ""children"": [ { ""text"": ""Yu-Gi-Oh! Ruling Queries"", ""href"": ""/wiki/Forum:Yu-Gi-Oh!_Ruling_Queries"" }, { ""text"": ""Yu-Gi-Oh! Deck Help"", ""href"": ""/wiki/Forum:Yu-Gi-Oh!_Deck_Help"" }, { ""text"": ""Yu-Gi-Oh! Lists Discussion"", ""href"": ""/wiki/Forum:Yu-Gi-Oh!_Lists_Discussion"" }, { ""text"": ""General Yu-Gi-Oh! Discussion"", ""href"": ""/wiki/Forum:General_Yu-Gi-Oh!_Discussion"" }, { ""text"": ""Duel Terminal"", ""href"": ""/wiki/Forum:Duel_Terminal"" }, { ""text"": ""Help desk"", ""href"": ""/wiki/Forum:Help_desk"" }, { ""text"": ""Yu-Gi-Oh! Wiki Community Discussion"", ""href"": ""/wiki/Forum:Yu-Gi-Oh!_Wiki_Community_Discussion"" }, { ""text"": ""Weekly Deck Competition"", ""href"": ""/wiki/Forum:Weekly_Deck_Competition"" } ] }, { ""text"": ""Recent Changes"", ""href"": ""/wiki/Special:RecentChanges"" }, { ""text"": ""Help"", ""href"": ""/wiki/Help:Contents"" } ] } ] } }");

            // Act
            await _sut.NavigationLinks();

            // Assert
            await _wikiaHttpClient.Received(1).GetString(Arg.Any<string>());
        }
    }
}