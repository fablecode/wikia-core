using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using wikia.Api;
using wikia.Configuration;
using wikia.Enums;
using wikia.Models.Activity;
using wikia.tests.core;

namespace wikia.unit.tests.WikiActivityTests
{
    [TestFixture]
    [Category(TestType.Unit)]
    public class ActivityRequestTests
    {
        private IWikiActivity _sut;
        private IWikiaHttpClient _wikiaHttpClient;
        private const string Url = "http://naruto.wikia.com";

        [SetUp]
        public void Setup()
        {
            _wikiaHttpClient = Substitute.For<IWikiaHttpClient>();
            _sut = new WikiActivity(Url, WikiaSettings.ApiVersion, _wikiaHttpClient);
        }

        [Test]
        public void Given_An_ActivityEndpoint_And_A_Null_ActivityRequestParameters_Should_Throw_ArgumentNullException()
        {
            // Arrange

            // Act
            Func<Task<ActivityResponseResult>> act = () => _sut.ActivityRequest(ActivityEndpoint.LatestActivity, null);

            // Assert
            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public async Task Given_An_ActivityEndpoint_And_ActivityRequestParameters_Should_Invoke_GetString_Once()
        {
            // Arrange

            // Act
            await _sut.ActivityRequest(ActivityEndpoint.LatestActivity, new ActivityRequestParameters());

            // Assert
            await _wikiaHttpClient.Received(1).GetString(Arg.Any<string>(), Arg.Any<Dictionary<string, string>>());
        }
    }


    [TestFixture]
    [Category(TestType.Unit)]
    public class LatestTests
    {
        private IWikiActivity _sut;
        private IWikiaHttpClient _wikiaHttpClient;
        private const string Url = "http://naruto.wikia.com";

        [SetUp]
        public void Setup()
        {
            _wikiaHttpClient = Substitute.For<IWikiaHttpClient>();
            _sut = new WikiActivity(Url, WikiaSettings.ApiVersion, _wikiaHttpClient);
        }

        [Test]
        public async Task Given_An_ActivityRequestParameters_Should_Return_Latest_Activities()
        {
            // Arrange
            _wikiaHttpClient.GetString(Arg.Any<string>(), Arg.Any<Dictionary<string, string>>()).Returns(@"{ ""items"": [ { ""article"": 342, ""user"": 1426382, ""revisionId"": 4196090, ""timestamp"": 1554048731 } ], ""basepath"": ""https://yugioh.fandom.com"" }");

            // Act
            var result = await _sut.Latest();

            // Assert
            result.Items.Should().NotBeEmpty();
        }

        [Test]
        public async Task Given_An_ActivityEndpoint_And_ActivityRequestParameters_Should_Invoke_GetString_Once()
        {
            // Arrange
            _wikiaHttpClient.GetString(Arg.Any<string>(), Arg.Any<Dictionary<string, string>>()).Returns(@"{ ""items"": [ { ""article"": 342, ""user"": 1426382, ""revisionId"": 4196090, ""timestamp"": 1554048731 } ], ""basepath"": ""https://yugioh.fandom.com"" }");

            // Act
            await _sut.ActivityRequest(ActivityEndpoint.LatestActivity, new ActivityRequestParameters());

            // Assert
            await _wikiaHttpClient.Received(1).GetString(Arg.Any<string>(), Arg.Any<Dictionary<string, string>>());
        }
    }

}