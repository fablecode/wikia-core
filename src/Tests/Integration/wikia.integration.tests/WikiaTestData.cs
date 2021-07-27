using System.Collections.Generic;
using NUnit.Framework;

namespace wikia.integration.tests
{
    public static class WikiaTestData
    {
        public static IEnumerable<TestCaseData> ArticleIdTestUrlData
        {
            get
            {
                yield return new TestCaseData
                (
                    "http://yugioh.fandom.com",
                    300400 // Eclipse  Wyvern card page
                );
                yield return new TestCaseData
                (
                    "http://naruto.fandom.com/",
                    1612 // Rock character page
                );
                yield return new TestCaseData
                (
                    "http://elderscrolls.fandom.com/",
                    41277 // Orc page
                );
            }
        }

        public static IEnumerable<TestCaseData> ArticleListTestData
        {
            get
            {
                yield return new TestCaseData
                (
                    "http://yugioh.fandom.com",
                    "Card_Tips"
                );
            }
        }
    }
}