using System.Collections.Generic;

namespace Algorithm
{
    internal class PairEqualityComparer : IEqualityComparer<Pair>
    {
        public bool Equals(Pair x, Pair y)
        {
            return (x.Person1 == y.Person1 && x.Person2 == y.Person2) ||
                (x.Person1 == y.Person2 && x.Person2 == y.Person1);
        }

        public int GetHashCode(Pair obj)
        {
            // We need to return the same hash code for Pair(x,y) and Pair(y, x)
            return obj.Person1.GetHashCode() + obj.Person2.GetHashCode();
        }
    }
}
