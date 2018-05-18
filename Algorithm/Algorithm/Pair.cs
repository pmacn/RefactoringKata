using System;

namespace Algorithm
{
    public class Pair
    {
        private Pair()
        {
            YoungerPerson = OlderPerson = null;
            AgeDifference = TimeSpan.Zero;
        }

        public Pair(Person youngerPerson, Person olderPerson)
        {
            YoungerPerson = youngerPerson ?? throw new ArgumentNullException(nameof(youngerPerson));
            OlderPerson = olderPerson ?? throw new ArgumentNullException(nameof(olderPerson));
            AgeDifference = OlderPerson.BirthDate - YoungerPerson.BirthDate;
        }

        public static readonly Pair Empty = new Pair();
        public Person YoungerPerson { get;}
        public Person OlderPerson { get; }
        public TimeSpan AgeDifference { get; }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) ||
                Equals(obj as Pair);
        }

        public bool Equals(Pair other)
        {
            return other != null &&
                (YoungerPerson == other.YoungerPerson && OlderPerson == other.OlderPerson) ||
                (YoungerPerson == other.OlderPerson && OlderPerson == other.YoungerPerson);
        }

        public override int GetHashCode()
        {
            // We need to return the same hash code for Pair(x,y) and Pair(y, x)
            return (YoungerPerson is null ? 0 : YoungerPerson.GetHashCode()) + (OlderPerson is null ? 0 : OlderPerson.GetHashCode());
        }
    }
}
