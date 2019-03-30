using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using wikia.Helper;
using wikia.tests.core;

namespace wikia.unit.tests.HelperTests
{
    [TestFixture]
    [Category(TestType.Unit)]
    public class UrlHelperTests
    {
        [TestCaseSource(nameof(UrlTestData))]
        public void Given_An_Absolute_And_RelativeUrl_Should_Generate_Url(string absoluteUrl, string relativeUrl, string expected)
        {
            // Arrange

            // Act
            var result = UrlHelper.GenerateUrl(absoluteUrl, relativeUrl);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        #region Test Data

        private static IEnumerable<TestCaseData> UrlTestData
        {
            get
            {
                yield return new TestCaseData
                (
                    "http://yugioh.wikia.com",
                    "/api/v1",
                    "http://yugioh.wikia.com/api/v1"
                );

                yield return new TestCaseData
                (
                    "http://yugioh.wikia.com/api/v1",
                    "/Articles/List",
                    "http://yugioh.wikia.com/api/v1/Articles/List"
                );
                yield return new TestCaseData
                (
                    "http://yugioh.wikia.com/api/v1/",
                    "/Articles/List",
                    "http://yugioh.wikia.com/api/v1/Articles/List"
                );
                yield return new TestCaseData
                (
                    "http://yugioh.wikia.com/api/v1/",
                    "Articles/List",
                    "http://yugioh.wikia.com/api/v1/Articles/List"
                );
            }
        }

        #endregion

    }
}