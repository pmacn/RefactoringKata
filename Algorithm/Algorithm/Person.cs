﻿using System;

namespace Algorithm
{
    public class Person
    {
        public Person(string name, DateTime birthDate)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            BirthDate = birthDate;
        }

        public string Name { get; }
        public DateTime BirthDate { get; }

        public bool IsOlderThan(Person other)
        {
            return other is null || BirthDate > other.BirthDate;
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || Equals(obj as Person);
        }

        public bool Equals(Person other)
        {
            return !(other is null) &&
                Name == other.Name && BirthDate == other.BirthDate;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() * 31 + BirthDate.GetHashCode();
        }
    }
}
