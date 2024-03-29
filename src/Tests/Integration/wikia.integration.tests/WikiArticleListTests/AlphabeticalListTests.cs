﻿using FluentAssertions;
using NUnit.Framework;
using System.Threading.Tasks;
using wikia.Services;
using wikia.tests.core;

namespace wikia.integration.tests.WikiArticleListTests
{
    [TestFixture]
    [Category(TestType.Integration)]
    public class AlphabeticalListTests
    {
        [TestCaseSource(typeof(WikiaTestData), nameof(WikiaTestData.ArticleListTestData))]
        public async Task Given_An_ArticleCategory_The_Response_Items_Collection_Should_Not_Be_Empty(string domainUrl, string category)
        {
            // Arrange
            var wikiaArticleList = new WikiArticleList(domainUrl);

            // Act
            var result = await wikiaArticleList.AlphabeticalList(category);

            // Assert
            result.Items.Should().NotBeEmpty();
        }
    }
}