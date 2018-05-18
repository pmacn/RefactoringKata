using System;
using System.Collections.Generic;
using Xunit;

namespace Algorithm.Test
{    
    public class FinderTests
    {
        public class Given_Empty_List
        {
            [Fact]
            public void Returns_Empty_Results()
            {
                var list = new List<Person>();
                var finder = new Finder(list);

                var result = finder.Find(FinderOption.Closest);

                Assert.Null(result.YoungerPerson);
                Assert.Null(result.OlderPerson);
            }
        }

        public class Given_One_Person
        {
            [Fact]
            public void Returns_Empty_Results()
            {
                var list = new List<Person>() { sue };
                var finder = new Finder(list);

                var result = finder.Find(FinderOption.Closest);

                Assert.Null(result.YoungerPerson);
                Assert.Null(result.OlderPerson);
            }
        }

        public class Given_Two_People
        {

            [Fact]
            public void Closest_Option_Returns_Pair_With_Lowest_Age_Difference()
            {
                var list = new List<Person>() { sue, greg };
                var finder = new Finder(list);

                var result = finder.Find(FinderOption.Closest);

                Assert.Same(sue, result.YoungerPerson);
                Assert.Same(greg, result.OlderPerson);
            }
            
            [Fact]
            public void Furthest_Option_Returns_Pair_With_Highest_Age_Difference()
            {
                var list = new List<Person>() { greg, mike };
                var finder = new Finder(list);

                var result = finder.Find(FinderOption.Furthest);

                Assert.Same(greg, result.YoungerPerson);
                Assert.Same(mike, result.OlderPerson);
            }
        }

        public class Given_Four_People
        {

            [Fact]
            public void Closest_Option_Returns_Pair_With_Lowest_Age_Difference()
            {
                var list = new List<Person>() { greg, mike, sarah, sue };
                var finder = new Finder(list);

                var result = finder.Find(FinderOption.Furthest);

                Assert.Same(sue, result.YoungerPerson);
                Assert.Same(sarah, result.OlderPerson);
            }

            [Fact]
            public void Furthest_Option_Returns_Pair_With_Highest_Age_Difference()
            {
                var list = new List<Person>() { greg, mike, sarah, sue };
                var finder = new Finder(list);

                var result = finder.Find(FinderOption.Closest);

                Assert.Same(sue, result.YoungerPerson);
                Assert.Same(greg, result.OlderPerson);
            }
        }

        public static Person sue = new Person("Sue", new DateTime(1950, 1, 1));
        public static Person greg = new Person("Greg", new DateTime(1952, 6, 1));
        public static Person sarah = new Person("Sarah", new DateTime(1982, 1, 1));
        public static Person mike = new Person("Mike", new DateTime(1979, 1, 1));
    }
}