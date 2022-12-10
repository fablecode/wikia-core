using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using wikia.Api;
using wikia.Configuration;
using wikia.Enums;
using wikia.Models.Activity;
using wikia.tests.core;

namespace wikia.unit.tests.WikiActivityTests
{
    [TestFixture]
    [Category(TestType.Unit)]
    public class LatestTests
    {
        private IWikiActivity _sut;
        private const string Url = "http://naruto.wikia.com";

        [SetUp]
        public void Setup()
        {
            _sut = new WikiActivity(Url);
        }

        [Test]
        public async Task Given_An_ActivityRequestParameters_Should_Return_Latest_Activities()
        {
            // Arrange

            // Act
            var result = await _sut.Latest();

            // Assert
            result.Items.Should().NotBeEmpty();
        }
    }
}