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
    public sealed class ActivityRequestTests
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
}