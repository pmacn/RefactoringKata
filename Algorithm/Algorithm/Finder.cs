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
            var tr = new List<Pair>();

            for(var i = 0; i < _people.Count - 1; i++)
            {
                for(var j = i + 1; j < _people.Count; j++)
                {
                    var r = new Pair();
                    if(_people[i].BirthDate < _people[j].BirthDate)
                    {
                        r.Person1 = _people[i];
                        r.Person2 = _people[j];
                    }
                    else
                    {
                        r.Person1 = _people[j];
                        r.Person2 = _people[i];
                    }
                    r.BirthdateDistance = r.Person2.BirthDate - r.Person1.BirthDate;
                    tr.Add(r);
                }
            }

            if(tr.Count < 1)
            {
                return new Pair();
            }

            Pair answer = tr[0];
            foreach(var result in tr)
            {
                switch(option)
                {
                    case FinderOption.Closest:
                        if(result.BirthdateDistance < answer.BirthdateDistance)
                        {
                            answer = result;
                        }
                        break;

                    case FinderOption.Furthest:
                        if(result.BirthdateDistance > answer.BirthdateDistance)
                        {
                            answer = result;
                        }
                        break;
                }
            }

            return answer;
        }
    }
}