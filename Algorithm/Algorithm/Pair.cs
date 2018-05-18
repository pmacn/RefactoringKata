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

        public override bool Equals(object obj)
        {

            return ReferenceEquals(this, obj) ||
                Equals(obj as Pair);
        }

        public bool Equals(Pair other)
        {
            return !ReferenceEquals(other, null) &&
                (Person1 == other.Person1 && Person2 == other.Person2) ||
                (Person1 == other.Person2 && Person2 == other.Person1);
        }

        public override int GetHashCode()
        {
            // We need to return the same hash code for Pair(x,y) and Pair(y, x)
            return Person1.GetHashCode() + Person2.GetHashCode();
        }
    }
}
