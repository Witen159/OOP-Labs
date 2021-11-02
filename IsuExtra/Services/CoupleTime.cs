using Isu.Tools;

namespace IsuExtra.Services
{
    public class CoupleTime
    {
        public CoupleTime(int day, int numberOfCouple)
        {
            if (day is <= 0 or > 14)
                throw new IsuException("Selected day outside the schedule");
            if (numberOfCouple is < 0 or > 7)
                throw new IsuException("Selected Couple outside the schedule");
            Day = day;
            NumberOfCouple = numberOfCouple;
        }

        public int Day { get; }
        public int NumberOfCouple { get; }

        public override bool Equals(object obj)
        {
            if (obj is CoupleTime objectType)
            {
                return this.Day == objectType.Day && this.NumberOfCouple == objectType.NumberOfCouple;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}