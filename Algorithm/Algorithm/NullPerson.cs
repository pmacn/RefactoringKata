using System;

namespace Algorithm
{
    public class NullPerson : Person
    {
        public NullPerson() : base(String.Empty, DateTime.MinValue)
        {
        }

        public override bool Equals(object obj) => false;

        public override int GetHashCode() => 0;

        public override string ToString() => "NullPerson";
    }
}
