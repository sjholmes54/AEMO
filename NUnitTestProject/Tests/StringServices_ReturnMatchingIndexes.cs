using NUnit.Framework;
using AEMO_Demo.Models;
using System.Collections.Generic;

namespace NUnitTestProject
{
    [TestFixture]
    public class StringServices_ReturnMatchingIndexes
    {
        private StringServices stringServices;
        [SetUp]
        public void Setup()
        {
            stringServices = new StringServices();
        }

        [Test]
        public void ReturnMatchingIndexes_BothParamsNull_ReturnEmptyList()
        {
            IList<int> l = stringServices.ReturnMatchingIndexes(null, null);
            Assert.IsTrue(l != null);
            Assert.IsTrue(l.Count == 0);
        }

        [Test]
        public void ReturnMatchingIndexes_Param1NullParam2Valid_ReturnEmptyList()
        {
            IList<int> l = stringServices.ReturnMatchingIndexes(null, "abc");
            Assert.IsTrue(l != null);
            Assert.IsTrue(l.Count == 0);
        }

        [Test]
        public void ReturnMatchingIndexes_Param1ValidParam2Null_ReturnEmptyList()
        {
            IList<int> l = stringServices.ReturnMatchingIndexes("abc", null);
            Assert.IsTrue(l != null);
            Assert.IsTrue(l.Count == 0);
        }

        [Test]
        public void ReturnMatchingIndexes_BothParamsEmpty_ReturnEmptyList()
        {
            IList<int> l = stringServices.ReturnMatchingIndexes("", "");
            Assert.IsTrue(l != null);
            Assert.IsTrue(l.Count == 0);
        }

        [Test]
        public void ReturnMatchingIndexes_Param1EmptyParam2Valid_ReturnEmptyList()
        {
            IList<int> l = stringServices.ReturnMatchingIndexes("", "abc");
            Assert.IsTrue(l != null);
            Assert.IsTrue(l.Count == 0);
        }

        [Test]
        public void ReturnMatchingIndexes_Param1ValidParam2Empty_ReturnEmptyList()
        {
            IList<int> l = stringServices.ReturnMatchingIndexes("abc", ""); 
            Assert.IsTrue(l != null);
            Assert.IsTrue(l.Count == 0);
        }

        [Test]
        public void ReturnMatchingIndexes_BothValuesEqual_ReturnValidResults()
        {
            IList<int> l = stringServices.ReturnMatchingIndexes("abc", "abc");
            Assert.IsTrue(l != null);
            Assert.IsTrue(l[0] == 0);
            Assert.IsTrue(l.Count == 1);
        }

        [Test]
        public void ReturnMatchingIndexes_BothValuesEqualCaseInsensitive_ReturnValidResults()
        {
            IList<int> l = stringServices.ReturnMatchingIndexes("abc", "ABC");
            Assert.IsTrue(l != null);
            Assert.IsTrue(l[0] == 0);
            Assert.IsTrue(l.Count == 1);
        }

        [Test]
        public void ReturnMatchingIndexes_Exactly1Match_ReturnValidResults()
        {
            IList<int> l = stringServices.ReturnMatchingIndexes("ababcbc", "abc");
            Assert.IsTrue(l != null);
            Assert.IsTrue(l[0] == 2);
            Assert.IsTrue(l.Count == 1);
        }

        [Test]
        public void ReturnMatchingIndexes_MultipleMatches_ReturnValidResults()
        {
            IList<int> l = stringServices.ReturnMatchingIndexes("ababcbcabc", "abc");
            Assert.IsTrue(l != null);
            Assert.IsTrue(l[0] == 2);
            Assert.IsTrue(l[1] == 7);
            Assert.IsTrue(l.Count == 2);
        }

        [Test]
        public void ReturnMatchingIndexes_MultipleMatchesOverlapping_ReturnValidResults()
        {
            IList<int> l = stringServices.ReturnMatchingIndexes("eweweWEWE", "eWe");
            Assert.IsTrue(l != null);
            Assert.IsTrue(l[0] == 0);
            Assert.IsTrue(l[1] == 2);
            Assert.IsTrue(l[2] == 4);
            Assert.IsTrue(l[3] == 6);
            Assert.IsTrue(l.Count == 4);
        }

        [Test]
        public void ReturnMatchingIndexes_ValidStringsButNoMatches_ReturnEmptyList()
        {
            IList<int> l = stringServices.ReturnMatchingIndexes("1", "123");
            Assert.IsTrue(l != null);
            Assert.IsTrue(l.Count == 0);
        }
    }
}