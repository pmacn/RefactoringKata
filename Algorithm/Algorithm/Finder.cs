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

        public F Find(FinderOption option)
        {
            var tr = new List<F>();

            for(var i = 0; i < _people.Count - 1; i++)
            {
                for(var j = i + 1; j < _people.Count; j++)
                {
                    var r = new F();
                    if(_people[i].BirthDate < _people[j].BirthDate)
                    {
                        r.P1 = _people[i];
                        r.P2 = _people[j];
                    }
                    else
                    {
                        r.P1 = _people[j];
                        r.P2 = _people[i];
                    }
                    r.D = r.P2.BirthDate - r.P1.BirthDate;
                    tr.Add(r);
                }
            }

            if(tr.Count < 1)
            {
                return new F();
            }

            F answer = tr[0];
            foreach(var result in tr)
            {
                switch(option)
                {
                    case FinderOption.Closest:
                        if(result.D < answer.D)
                        {
                            answer = result;
                        }
                        break;

                    case FinderOption.Furthest:
                        if(result.D > answer.D)
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