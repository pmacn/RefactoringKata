using System.Collections.Generic;

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
            List<Pair> pairs = GeneratePairs();

            if (pairs.Count < 1)
            {
                return new Pair();
            }

            Pair answer = pairs[0];
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

        private List<Pair> GeneratePairs()
        {
            var pairs = new List<Pair>();

            for (var i = 0; i < _people.Count - 1; i++)
            {
                for (var j = i + 1; j < _people.Count; j++)
                {
                    var r = new Pair();
                    if (_people[i].BirthDate < _people[j].BirthDate)
                    {
                        r.Person1 = _people[i];
                        r.Person2 = _people[j];
                    }
                    else
                    {
                        r.Person1 = _people[j];
                        r.Person2 = _people[i];
                    }
                    r.BirthDateDistance = r.Person2.BirthDate - r.Person1.BirthDate;
                    pairs.Add(r);
                }
            }

            return pairs;
        }
    }
}