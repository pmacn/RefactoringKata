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

                Assert.Null(result.Person1);
                Assert.Null(result.Person2);
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

                Assert.Null(result.Person1);
                Assert.Null(result.Person2);
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

                Assert.Same(sue, result.Person1);
                Assert.Same(greg, result.Person2);
            }
            
            [Fact]
            public void Furthest_Option_Returns_Pair_With_Highest_Age_Difference()
            {
                var list = new List<Person>() { greg, mike };
                var finder = new Finder(list);

                var result = finder.Find(FinderOption.Furthest);

                Assert.Same(greg, result.Person1);
                Assert.Same(mike, result.Person2);
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

                Assert.Same(sue, result.Person1);
                Assert.Same(sarah, result.Person2);
            }

            [Fact]
            public void Furthest_Option_Returns_Pair_With_Highest_Age_Difference()
            {
                var list = new List<Person>() { greg, mike, sarah, sue };
                var finder = new Finder(list);

                var result = finder.Find(FinderOption.Closest);

                Assert.Same(sue, result.Person1);
                Assert.Same(greg, result.Person2);
            }
        }

        public static Person sue = new Person() { Name = "Sue", BirthDate = new DateTime(1950, 1, 1) };
        public static Person greg = new Person() { Name = "Greg", BirthDate = new DateTime(1952, 6, 1) };
        public static Person sarah = new Person() { Name = "Sarah", BirthDate = new DateTime(1982, 1, 1) };
        public static Person mike = new Person() { Name = "Mike", BirthDate = new DateTime(1979, 1, 1) };
    }
}