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
            foreach (var result in pairs.Skip(1))
            {
                answer = PickBestAnswer(answer, result, option);
            }

            return answer;
        }

        private static Pair PickBestAnswer(Pair currentAnswer, Pair candidateAnswer, FinderOption option)
        {
            bool candidateIsBetterAnswer = (option == FinderOption.Closest && candidateAnswer.BirthDateDistance < currentAnswer.BirthDateDistance) ||
                (option == FinderOption.Furthest && candidateAnswer.BirthDateDistance > currentAnswer.BirthDateDistance);
            return candidateIsBetterAnswer ? candidateAnswer : currentAnswer;
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
