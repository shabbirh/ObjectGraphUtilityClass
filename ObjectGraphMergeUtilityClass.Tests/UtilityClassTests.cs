using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObjectGraphMergeUtilityClass.Entities;

namespace ObjectGraphMergeUtilityClass.Tests
{
    [TestClass]
    public class UtilityClassTests
    {
        private Library _sourceLibrary;
        private Library _targetLibrary;
        private Library _mergedLibrary;
        private Library _libraryWithNulls;


        // test tearup
        public UtilityClassTests()
        {
            // tear up two libraries with books that will be used through-out the test.

            _sourceLibrary = CreateLibrary(true);
            _targetLibrary = CreateLibrary();
            _libraryWithNulls = CreateLibrary(false, true);

        }

        private static Library CreateLibrary(bool isSource=false, bool withNulls=false)
        {
            // authors
            var HarperLee = new Author()
            {
                Id = new Guid("81238428-7376-4BF1-BE53-5945D8BDC8CA"),
                Name = @"Harper Lee",
                Rating = 5
            };

            var IsaacAsimov = new Author()
            {
                Id = new Guid("91238428-7376-4BF1-BE53-5945D8BDC8CA"),
                Name = @"Isaac Asimov",
                Rating = 5
            };

            // books
            var ToKillAMockingBird = new Book()
            {
                Id = new Guid("8B888428-7376-4BF1-BE53-5945D8BDC8CA"),
                Name = @"To Kill A Mocking Bird",
                CatalogNumber = 1,
                Author = HarperLee,
            };

            var GoSetAWatchman = new Book()
            {
                Id = new Guid("8B888428-7376-4BF1-1253-5945D8BDC8CA"),
                Name = @"Go Set A Watchman",
                CatalogNumber = 2,
                Author = HarperLee,
            };

            var IRobot = new Book()
            {
                Id = new Guid("12348428-7376-4BF1-1253-5945D8BDC8CA"),
                Name = @"I, Robot",
                CatalogNumber = 3,
                Author = IsaacAsimov,
            };

            // library
            var ReturnLibrary = new Library
            {
                Books = new List<Book>()
            };

            ReturnLibrary.Books.Add(ToKillAMockingBird);
            ReturnLibrary.Books.Add(GoSetAWatchman);

            if (isSource)
            {
                // will only add Asimov titles to source library.
                ReturnLibrary.Books.Add(IRobot);
            }

            if (withNulls)
            {
                ReturnLibrary.Books.Add(null);
            }

            return ReturnLibrary;
        }

        [TestMethod]
        [TestCategory("Ensure Library PreMerge")]
        public void CheckSourceLibraryContentsTest()
        {
            Assert.AreEqual(3, _sourceLibrary.Books.Count);
        }

        [TestMethod]
        [TestCategory("Ensure Library PreMerge")]
        public void CheckTargetLibraryContentsTest()
        {
            Assert.AreEqual(2, _targetLibrary.Books.Count);
        }

        [TestMethod]
        [TestCategory("Ensure Library PreMerge")]
        [ExpectedException(typeof(NullReferenceException))]
        public void MergeSourceWithTargetLibraryBeforeMergingTest()
        {
            Assert.AreEqual(5, _mergedLibrary.Books.Count);
        }

        [TestMethod]
        [TestCategory("Ensure Library PreMerge")]
        [ExpectedException(typeof(NullReferenceException))]
        public void CheckLibraryWithNullBookTest()
        {
            var tmp = string.Empty;
            foreach(Book b in _libraryWithNulls.Books)
            {
                tmp = b.Name;
            }
        }

        [TestMethod]
        [TestCategory("Ensure Library PostMerge NoNulls Clean Merge")]
        public void MergeSourceWithTargetLibraryTest()
        {
            _mergedLibrary = _sourceLibrary.MergeWith(_targetLibrary);

            Assert.AreEqual(5, _mergedLibrary.Books.Count);
        }

        [TestMethod]
        [TestCategory("With Nulls in Source")]
        public void MergeSourceWithNullsAndTargetLibraryTest()
        {
            _mergedLibrary = _libraryWithNulls.MergeWith(_targetLibrary);

            Assert.AreEqual(5, _mergedLibrary.Books.Count);
        }

        [TestMethod]
        [TestCategory("Merge With Rules - No Nulls")]
        public void MergeSourceWithTargetWithRulesWithoutNullsTest()
        {
            _mergedLibrary = _sourceLibrary.MergeWithRules(_targetLibrary);

            Assert.AreEqual(5, _mergedLibrary.Books.Count);
        }

    }
}
