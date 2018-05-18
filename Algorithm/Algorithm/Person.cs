using System;

namespace Algorithm
{
    public class Person
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

        public bool IsOlderThan(Person other)
        {
            return other == null || BirthDate > other.BirthDate;
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || Equals(obj as Person);
        }

        public bool Equals(Person other)
        {
            return !ReferenceEquals(other, null) &&
                Name == other.Name && BirthDate == other.BirthDate;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() * 31 + BirthDate.GetHashCode();
        }
    }
}
