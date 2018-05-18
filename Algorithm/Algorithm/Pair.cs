using System;

namespace Algorithm
{
    public class Pair
    {
        private Pair()
        {
            Person1 = Person2 = null;
            AgeDifference = TimeSpan.Zero;
        }

        public Pair(Person person1, Person person2)
        {
            Person1 = person1 ?? throw new ArgumentNullException(nameof(person1));
            Person2 = person2 ?? throw new ArgumentNullException(nameof(person2));
            AgeDifference = Person2.BirthDate - Person1.BirthDate;
        }

        public static readonly Pair Empty = new Pair();
        public Person Person1 { get;}
        public Person Person2 { get; }
        public TimeSpan AgeDifference { get; }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) ||
                Equals(obj as Pair);
        }

        public bool Equals(Pair other)
        {
            return other != null &&
                (Person1 == other.Person1 && Person2 == other.Person2) ||
                (Person1 == other.Person2 && Person2 == other.Person1);
        }

        public override int GetHashCode()
        {
            // We need to return the same hash code for Pair(x,y) and Pair(y, x)
            return (Person1 is null ? 0 : Person1.GetHashCode()) + (Person2 is null ? 0 : Person2.GetHashCode());
        }
    }
}
