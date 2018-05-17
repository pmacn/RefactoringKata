using System;

namespace Algorithm
{
    public class Pair
    {
        public Pair()
        {
        }

        public Pair(Person person1, Person person2)
        {
            Person1 = person1;
            Person2 = person2;
            AgeDifference = Person2.BirthDate - Person1.BirthDate;
        }

        public Person Person1 { get; private set; }
        public Person Person2 { get; private set; }
        public TimeSpan AgeDifference { get; private set; }
    }
}
