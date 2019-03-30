using FluentAssertions;
using NUnit.Framework;
using wikia.Helper;
using wikia.Models.Article.Simple;
using wikia.tests.core;

namespace wikia.unit.tests.HelperTests
{
    [TestFixture]
    [Category(TestType.Unit)]
    public class JsonHelperTests
    {
        [Test]
        public void Given_A_Json_String_Value_Should_Deserialize_To_Object()
        {
            // Arrange
            const string json = @"{ ""sections"": [ { ""title"": ""Solemn Wishes"", ""level"": 1, ""content"": [], ""images"": [] } ] }";

            // Act
            var result = JsonHelper.Deserialize<ContentResult>(json);

            // Assert
            result.Should().NotBeNull().And.BeOfType<ContentResult>();
        }
    }
}