using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithm
{
    public class Finder
    {
        private readonly IEnumerable<Person> _people;

        public Finder(IEnumerable<Person> people)
        {
            _people = people;
        }

        public Pair Find(FinderOption option)
        {
            IEnumerable<Pair> pairs = GeneratePairs();

            return (option == FinderOption.Closest ?
                FindPairWithSmallestAgeDifference(pairs) :
                FindPairWithLargestAgeDifference(pairs)) ?? Pair.Empty;
        }

        private static Pair FindPairWithSmallestAgeDifference(IEnumerable<Pair> pairs)
        {
            return pairs.OrderBy(p => p.AgeDifference).FirstOrDefault();
        }

        private static Pair FindPairWithLargestAgeDifference(IEnumerable<Pair> pairs)
        {
            return pairs.OrderByDescending(p => p.AgeDifference).FirstOrDefault();
        }

        private IEnumerable<Pair> GeneratePairs()
        {
            return (from x in _people
                   from y in _people
                   where y.IsOlderThan(x) && !x.Equals(y)
                   select new Pair(x, y))
                .Distinct();
        }
    }
}
