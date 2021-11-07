using System;
using Isu.Services;
using Isu.Tools;

namespace IsuExtra.Services
{
    public class Couple
    {
        public Couple(CoupleTime coupleTime, string teacher, int auditorium)
        {
            CoupleTime = coupleTime;
            Teacher = teacher;
            Auditorium = auditorium;
        }

        public string Teacher { get; }
        public int Auditorium { get; }
        public CoupleTime CoupleTime { get; }

        public override bool Equals(object obj)
        {
            if (obj is Couple objectType)
            {
                return Equals(this.CoupleTime, objectType.CoupleTime);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Teacher, Auditorium, CoupleTime);
        }
    }
}