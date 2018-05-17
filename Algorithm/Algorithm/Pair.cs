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
            BirthDateDistance = Person2.BirthDate - Person1.BirthDate;
        }

        public Person Person1 { get; set; }
        public Person Person2 { get; set; }
        public TimeSpan BirthDateDistance { get; set; }
    }
}
