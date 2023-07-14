using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace IncomprehensibleFinderKata.Tests {
    [TestClass]
    public class FinderTests {
        [TestMethod]
        public void Returns_Empty_Results_When_Given_Empty_List() {
            var list = new List<Thing>();
            var finder = new Finder(list);

            var result = finder.Find(FT.One);

            Assert.IsNull(result.P1);
            Assert.IsNull(result.P2);
        }

        [TestMethod]
        public void Returns_Empty_Results_When_Given_One_Person() {
            var list = new List<Thing>() {sue};
            var finder = new Finder(list);

            var result = finder.Find(FT.One);

            Assert.IsNull(result.P1);
            Assert.IsNull(result.P2);
        }

        [TestMethod]
        public void Returns_Closest_Two_For_Two_People() {
            var list = new List<Thing>() {sue, greg};
            var finder = new Finder(list);

            var result = finder.Find(FT.One);

            Assert.AreEqual(sue, result.P1);
            Assert.AreEqual(greg, result.P2);
        }

        [TestMethod]
        public void Returns_Furthest_Two_For_Two_People() {
            var list = new List<Thing>() {greg, mike};
            var finder = new Finder(list);

            var result = finder.Find(FT.Two);

            Assert.AreEqual(greg, result.P1);
            Assert.AreEqual(mike, result.P2);
        }

        [TestMethod]
        public void Returns_Furthest_Two_For_Four_People() {
            var list = new List<Thing>() {greg, mike, sarah, sue};
            var finder = new Finder(list);

            var result = finder.Find(FT.Two);

            Assert.AreEqual(sue, result.P1);
            Assert.AreEqual(sarah, result.P2);
        }

        [TestMethod]
        public void Returns_Closest_Two_For_Four_People() {
            var list = new List<Thing>() {greg, mike, sarah, sue};
            var finder = new Finder(list);

            var result = finder.Find(FT.One);

            Assert.AreEqual(sue, result.P1);
            Assert.AreEqual(greg, result.P2);
        }

        Thing sue = new Thing() {Name = "Sue", BirthDate = new DateTime(1950, 1, 1)};
        Thing greg = new Thing() {Name = "Greg", BirthDate = new DateTime(1952, 6, 1)};
        Thing sarah = new Thing() {Name = "Sarah", BirthDate = new DateTime(1982, 1, 1)};
        Thing mike = new Thing() {Name = "Mike", BirthDate = new DateTime(1979, 1, 1)};
    }
}