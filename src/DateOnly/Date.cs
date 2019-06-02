using System;

namespace mdsharpe.DateOnly
{
    public struct Date : IEquatable<Date>
    {
        public int Year { get; }
        public int Month { get; }
        public int Day { get; }

        public Date(int year, int month, int day)
        {
            Year = year;
            Month = month;
            Day = day;
        }

        public static bool operator ==(Date d1, Date d2) => d1.Equals(d2);
        public static bool operator !=(Date d1, Date d2) => !d1.Equals(d2);

        public override bool Equals(object obj)
        {
            if (obj is DateTime other)
            {
                return Equals(other);
            }

            return false;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = (int)2166136261;
                hash = (hash * 16777619) ^ Year.GetHashCode();
                hash = (hash * 16777619) ^ Month.GetHashCode();
                hash = (hash * 16777619) ^ Day.GetHashCode();
                return hash;
            }
        }

        public bool Equals(Date other)
            => other.Year == this.Year && other.Month == this.Month && other.Day == this.Day;
    }
}
