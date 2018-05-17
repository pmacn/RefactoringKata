using System.Collections.Generic;
using System.Linq;

namespace Algorithm
{
    public class Finder
    {
        private readonly List<Person> _people;

        public Finder(List<Person> people)
        {
            _people = people;
        }

        public Pair Find(FinderOption option)
        {
            IEnumerable<Pair> pairs = GeneratePairs();

            return (option == FinderOption.Closest ?
                pairs.OrderBy(p => p.AgeDifference).FirstOrDefault() :
                pairs.OrderByDescending(p => p.AgeDifference).FirstOrDefault()) ?? new Pair();
        }

        private IEnumerable<Pair> GeneratePairs()
        {
            return (from x in _people
                   from y in _people
                   where y.IsOlderThan(x) && !x.Equals(y)
                   select new Pair(x, y))
                .Distinct(new PairEqualityComparer());
        }
    }
}
