﻿using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using wikia.Api;
using wikia.Configuration;
using wikia.Models.Search;
using wikia.tests.core;

namespace wikia.unit.tests.WikiSearchTests
{
    [TestFixture]
    [Category(TestType.Unit)]
    public class SearchListTests
    {
        private WikiSearch _sut;
        private IWikiaHttpClient _wikiaHttpClient;
        private const string Url = "http://yugioh.fandom.com";

        [SetUp]
        public void Setup()
        {
            _sut = new WikiSearch(Url);
        }

        [Test]
        public void Given_A_Null_SearchListRequestParameter_Should_Throw_ArgumentNullException()
        {
            // Arrange
            // Act
            Func<Task<LocalWikiSearchResultSet>> act = () => _sut.SearchList(null);

            // Assert
            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public async Task Given_A_SearchListRequestParameter_Should_Execute_Successfully()
        {
            // Arrange

            // Act
            var result = await _sut.SearchList(new SearchListRequestParameter("query")
            {
                Type = "Videos",
                Rank = "Oldest"
            });

            // Assert
            result.Batches.Should().NotBeEmpty();
        }

        [Test]
        public async Task Given_A_SearchListRequestParameter_Should_Invoke_GetString_Once()
        {
            // Arrange
            _wikiaHttpClient.GetString(Arg.Any<string>(), Arg.Any<Dictionary<string, string>>()).Returns(@"{ ""total"": 1335, ""batches"": 54, ""currentBatch"": ""1"", ""next"": 26, ""items"": [ { ""id"": 149, ""title"": ""Jinzo"", ""url"": ""https://yugioh.fandom.com/wiki/Jinzo"", ""ns"": 0, ""quality"": 98, ""snippet"": ""This article is about the card. For the character, see <span class=\""searchmatch\"">Jinzo</span> (character). For the archetype, see <span class=\""searchmatch\"">Jinzo</span> (archetype). The Arabic, Croatian, Danish, Greek, Thai andTurkish names given are not official. (card names&hellip;"" }, { ""id"": 142661, ""title"": ""Jinzo (archetype)"", ""url"": ""http://yugioh.fandom.com/wiki/Jinzo_(archetype)"", ""ns"": 0, ""quality"": 96, ""snippet"": ""<span class=\""searchmatch\"">Jinzo</span> 人造人間 「じんぞうにんげん 」 (Jinzōningen ) Translation Android Other names Chinese 人造人 Translation: Android French <span class=\""searchmatch\"">Jinzo</span> German <span class=\""searchmatch\"">Jinzo</span> Italian <span class=\""searchmatch\"">Jinzo</span> Korean&hellip;"" }, { ""id"": 56659, ""title"": ""Jinzo (character)"", ""url"": ""http://yugioh.wikia.com/wiki/Jinzo_(character)"", ""ns"": 0, ""quality"": 98, ""snippet"": ""<span class=\""searchmatch\"">Jinzo</span> Corresponding card <span class=\""searchmatch\"">Jinzo</span> English name <span class=\""searchmatch\"">Jinzo</span> Japanese translated Android - Psycho Shocker Japanese name 人（じん）造（ぞう）人（にん）間（げん） －サイコ・ショッカー 人造人間&hellip;"" }, { ""id"": 402128, ""title"": ""Jinzo Art"", ""url"": ""http://yugioh.wikia.com/wiki/Jinzo_Art"", ""ns"": 0, ""quality"": 11, ""snippet"": ""<span class=\""searchmatch\"">Jinzo</span> Art, or <span class=\""searchmatch\"">Jinzo</span> Legacy, known as Psycho Art (サイコ流 Saiko Ryū) in the Japanese version, is a term used in the Yu-Gi-Oh! GX anime. It denotes&hellip;"" }, { ""id"": 71747, ""title"": ""Jinzo - Returner"", ""url"": ""http://yugioh.wikia.com/wiki/Jinzo_-_Returner"", ""ns"": 0, ""quality"": 89, ""snippet"": ""<span class=\""searchmatch\"">Jinzo</span> - Returner 人（じん）造（ぞう）人（にん）間（げん）－サイコ・リターナー English <span class=\""searchmatch\"">Jinzo</span> - Returner Chinese 人造人－念力归来者 Check translation French Résurrecteur <span class=\""searchmatch\"">Jinzo</span> Check&hellip;"" }, { ""id"": 72705, ""title"": ""Jinzo - Lord"", ""url"": ""http://yugioh.wikia.com/wiki/Jinzo_-_Lord"", ""ns"": 0, ""quality"": 94, ""snippet"": ""<span class=\""searchmatch\"">Jinzo</span> - Lord 人（じん）造（ぞう）人（にん）間（げん）－サイコ・ロード English <span class=\""searchmatch\"">Jinzo</span> - Lord Chinese 人造人－念力王者 Check translation French Seigneur <span class=\""searchmatch\"">Jinzo</span> Check translation German&hellip;"" }, { ""id"": 485423, ""title"": ""Jinzo - Jector"", ""url"": ""http://yugioh.wikia.com/wiki/Jinzo_-_Jector"", ""ns"": 0, ""quality"": 95, ""snippet"": ""<span class=\""searchmatch\"">Jinzo</span> - Jector 人（じん）造（ぞう）人（にん）間（げん）－サイコ・ジャッカー English <span class=\""searchmatch\"">Jinzo</span> - Jector French Injecteur <span class=\""searchmatch\"">Jinzo</span> Check translation German <span class=\""searchmatch\"">Jinzo</span> - Jektor Check translation&hellip;"" }, { ""id"": 516531, ""title"": ""Jinzo (later anime)"", ""url"": ""http://yugioh.wikia.com/wiki/Jinzo_(later_anime)"", ""ns"": 0, ""quality"": 87, ""snippet"": ""Main card page: \""<span class=\""searchmatch\"">Jinzo</span>\"" <span class=\""searchmatch\"">Jinzo</span> Japanese: 人造人間－サイコ・ショッカー Romaji: Jinzōningen - Saiko Shokkā Translated: Android - Psycho Shocker Anime cards (Galleries&hellip;"" }, { ""id"": 504105, ""title"": ""Jinzo (anime)"", ""url"": ""http://yugioh.wikia.com/wiki/Jinzo_(anime)"", ""ns"": 0, ""quality"": 90, ""snippet"": ""Main card page: \""<span class=\""searchmatch\"">Jinzo</span>\"" <span class=\""searchmatch\"">Jinzo</span> Japanese: 人造人間－サイコ・ショッカー Romaji: Jinzōningen - Saiko Shokkā Translated: Android - Psycho Shocker ja dub Anime cards&hellip;"" }, { ""id"": 6636, ""title"": ""Jinzo 7"", ""url"": ""http://yugioh.wikia.com/wiki/Jinzo_7"", ""ns"": 0, ""quality"": 93, ""snippet"": ""<span class=\""searchmatch\"">Jinzo</span> #7 人（じん）造（ぞう）人（にん）間（げん）７号（ごう） English <span class=\""searchmatch\"">Jinzo</span> #7 Chinese 人造人7號 Check translation French <span class=\""searchmatch\"">Jinzo</span> N°7 Check translation German <span class=\""searchmatch\"">Jinzo</span> #7 Check&hellip;"" }, { ""id"": 58482, ""title"": ""Jinzo (DDM)"", ""url"": ""http://yugioh.wikia.com/wiki/Jinzo_(DDM)"", ""ns"": 0, ""quality"": 48, ""snippet"": ""Main card page: \""<span class=\""searchmatch\"">Jinzo</span>\"" <span class=\""searchmatch\"">Jinzo</span> Japanese: 人造人間－サイコ・ショッカー Romaji: Jinzōningen - Saiko Shokkā Translated: Android - Psycho Shocker Dungeon Dice Monsters&hellip;"" }, { ""id"": 475724, ""title"": ""Jinzo (manga)"", ""url"": ""http://yugioh.wikia.com/wiki/Jinzo_(manga)"", ""ns"": 0, ""quality"": 86, ""snippet"": ""Main card page: \""<span class=\""searchmatch\"">Jinzo</span>\"" <span class=\""searchmatch\"">Jinzo</span> Japanese: 人造人間－サイコ・ショッカー Romaji: Jinzōningen - Saiko Shokkā Translated: Android - Psycho Shocker ja color en ja Manga&hellip;"" }, { ""id"": 590258, ""title"": ""Jinzo (DBT)"", ""url"": ""http://yugioh.wikia.com/wiki/Jinzo_(DBT)"", ""ns"": 0, ""quality"": 79, ""snippet"": ""Main card page: \""<span class=\""searchmatch\"">Jinzo</span>\"" <span class=\""searchmatch\"">Jinzo</span> Japanese: 人造人間－サイコ・ショッカー Romaji: Jinzōningen - Saiko Shokkā Translated: Android - Psycho Shocker #751: Gear Golem&hellip;"" }, { ""id"": 269088, ""title"": ""List of \""Jinzo\"" cards"", ""url"": ""http://yugioh.wikia.com/wiki/List_of_%22Jinzo%22_cards"", ""ns"": 0, ""quality"": 90, ""snippet"": ""Contents[show] This is a list of \""<span class=\""searchmatch\"">Jinzo</span>\"" cards. \""<span class=\""searchmatch\"">Jinzo</span>\"" is an archetype in the OCG/TCG, and a series in the anime. For a list of support cards&hellip;"" }, { ""id"": 159518, ""title"": ""Jinzo - Lord (character)"", ""url"": ""http://yugioh.wikia.com/wiki/Jinzo_-_Lord_(character)"", ""ns"": 0, ""quality"": 91, ""snippet"": ""<span class=\""searchmatch\"">Jinzo</span> - Lord, known as Android - Psycho Lord in the Japanese version, is a character version of the card, \""<span class=\""searchmatch\"">Jinzo</span> - Lord\"" and an upgraded version&hellip;"" }, { ""id"": 681777, ""title"": ""Jinzo (Tag Force)"", ""url"": ""http://yugioh.wikia.com/wiki/Jinzo_(Tag_Force)"", ""ns"": 0, ""quality"": 96, ""snippet"": ""<span class=\""searchmatch\"">Jinzo</span> Corresponding card <span class=\""searchmatch\"">Jinzo</span> English name <span class=\""searchmatch\"">Jinzo</span> Japanese translated Android - Psycho Shocker Japanese name 人（じん）造（ぞう）人（にん）間（げん） －サイコ・ショッカー 人造人間&hellip;"" }, { ""id"": 473848, ""title"": ""Jinzo (Duel Arena)"", ""url"": ""http://yugioh.wikia.com/wiki/Jinzo_(Duel_Arena)"", ""ns"": 0, ""quality"": 98, ""snippet"": ""<span class=\""searchmatch\"">Jinzo</span> Corresponding card <span class=\""searchmatch\"">Jinzo</span> English name <span class=\""searchmatch\"">Jinzo</span> Gender Male Duel Arena Decree of the <span class=\""searchmatch\"">Jinzo</span> Video game debut Yu-Gi-Oh! Duel Arena PC appearances Yu&hellip;"" }, { ""id"": 517640, ""title"": ""Jinzo - Returner (anime)"", ""url"": ""http://yugioh.wikia.com/wiki/Jinzo_-_Returner_(anime)"", ""ns"": 0, ""quality"": 84, ""snippet"": ""Main card page: \""<span class=\""searchmatch\"">Jinzo</span> - Returner\"" <span class=\""searchmatch\"">Jinzo</span> - Returner Japanese: 人造人間－サイコ・リターナー Romaji: Jinzōningen - Saiko Ritānā Translated: Android - Psycho Returner&hellip;"" }, { ""id"": 517639, ""title"": ""Jinzo - Lord (anime)"", ""url"": ""http://yugioh.wikia.com/wiki/Jinzo_-_Lord_(anime)"", ""ns"": 0, ""quality"": 89, ""snippet"": ""Main card page: \""<span class=\""searchmatch\"">Jinzo</span> - Lord\"" <span class=\""searchmatch\"">Jinzo</span> - Lord Japanese: 人造人間－サイコ・ロード Romaji: Jinzōningen - Saiko Rōdo Translated: Android - Psycho Lord Anime cards&hellip;"" }, { ""id"": 433572, ""title"": ""Jinzo - Lord (BAM)"", ""url"": ""http://yugioh.wikia.com/wiki/Jinzo_-_Lord_(BAM)"", ""ns"": 0, ""quality"": 50, ""snippet"": ""Main card page: \""<span class=\""searchmatch\"">Jinzo</span> - Lord\"" <span class=\""searchmatch\"">Jinzo</span> - Lord Yu-Gi-Oh! BAM cards Attribute DARK Type Machine / Effect Level 11 Power/Life Points 3000 / 500 SPECIAL&hellip;"" }, { ""id"": 447061, ""title"": ""Jinzo 7 (FMR)"", ""url"": ""http://yugioh.wikia.com/wiki/Jinzo_7_(FMR)"", ""ns"": 0, ""quality"": 37, ""snippet"": ""Main card page: \""<span class=\""searchmatch\"">Jinzo</span> 7\"" <span class=\""searchmatch\"">Jinzo</span> #7 人造人間７号 Japanese: 人造人間７号 Romaji: Jinzōningen Nana-gō Translated: Android No.7 #421: Cyber Commander #423: Dice&hellip;"" }, { ""id"": 438468, ""title"": ""Jinzo 7 (DOR)"", ""url"": ""http://yugioh.wikia.com/wiki/Jinzo_7_(DOR)"", ""ns"": 0, ""quality"": 42, ""snippet"": ""Main card page: \""<span class=\""searchmatch\"">Jinzo</span> 7\"" <span class=\""searchmatch\"">Jinzo</span> #7 人（じん）造（ぞう）人（にん）間（げん）７号（ごう） Japanese: 人造人間７号 Romaji: Jinzōningen Nana-gō Translated: Android No.7 #496: Cyber&hellip;"" }, { ""id"": 588590, ""title"": ""Jinzo 7 (DBT)"", ""url"": ""http://yugioh.wikia.com/wiki/Jinzo_7_(DBT)"", ""ns"": 0, ""quality"": 70, ""snippet"": ""Main card page: \""<span class=\""searchmatch\"">Jinzo</span> 7\"" <span class=\""searchmatch\"">Jinzo</span> #7 Japanese: 人造人間７号 Romaji: Jinzōningen Nana-gō Translated: Android No.7 #421: Cyber Commander #423: Dice Armadillo&hellip;"" }, { ""id"": 595607, ""title"": ""Jinzo (DDM video game)"", ""url"": ""http://yugioh.wikia.com/wiki/Jinzo_(DDM_video_game)"", ""ns"": 0, ""quality"": 73, ""snippet"": ""Main card page: \""<span class=\""searchmatch\"">Jinzo</span>\"" <span class=\""searchmatch\"">Jinzo</span> Japanese: 人造人間－サイコ・ショッカー Kana: じんぞうにんげん－サイコ・ショッカー Romaji: Jinzōningen - Saiko Shokkā Translated: Android - Psycho&hellip;"" }, { ""id"": 661419, ""title"": ""Jinzo 7 (DM2)"", ""url"": ""http://yugioh.wikia.com/wiki/Jinzo_7_(DM2)"", ""ns"": 0, ""quality"": 31, ""snippet"": ""Main card page: \""<span class=\""searchmatch\"">Jinzo</span> 7\"" <span class=\""searchmatch\"">Jinzo</span> #7 Japanese: じんぞうにんげん７ごう Romaji: Jinzōningen Nana-gō Translated: Android No.7 #421: Cyber Commander #423: Dice&hellip;"" } ] }");

            // Act
            await _sut.SearchList(new SearchListRequestParameter("query")
            {
                Type = "Videos",
                Rank = "Oldest"
            });

            // Assert
            await _wikiaHttpClient.Received(1).GetString(Arg.Any<string>(), Arg.Any<Dictionary<string, string>>());
        }
    }
}