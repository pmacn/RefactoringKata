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

            if (pairs.Count() < 1)
            {
                return new Pair();
            }

            Pair answer = pairs.First();
            foreach (var result in pairs)
            {
                switch (option)
                {
                    case FinderOption.Closest:
                        if (result.BirthDateDistance < answer.BirthDateDistance)
                        {
                            answer = result;
                        }
                        break;

                    case FinderOption.Furthest:
                        if (result.BirthDateDistance > answer.BirthDateDistance)
                        {
                            answer = result;
                        }
                        break;
                }
            }

            return answer;
        }

        private IEnumerable<Pair> GeneratePairs()
        {
            return (from x in _people
                   from y in _people
                   where x.BirthDate <= y.BirthDate && !x.Equals(y)
                   select new Pair(x, y)).Distinct(new PairEqualityComparer());
        }
    }
}
