using System.Collections.Generic;
using Banks.Tools;

namespace Banks.Classes.Bank
{
    public class PercentAmount
    {
        private List<int> _moneyBorders;
        private List<double> _percents;
        public PercentAmount(List<int> moneyBorders, List<double> percents)
        {
            Setup(moneyBorders, percents);
        }

        public IReadOnlyList<int> MoneyBorders => _moneyBorders;
        public IReadOnlyList<double> Percents => _percents;

        public void ChangePercentAmount(List<int> moneyBorders, List<double> percents)
        {
            Setup(moneyBorders, percents);
        }

        public double GetCurrentPercent(double money)
        {
            for (int i = 0; i < _moneyBorders.Count; i++)
            {
                if (money < _moneyBorders[i])
                    return _percents[i];
            }

            return _percents[^1];
        }

        private void Setup(List<int> moneyBorders, List<double> percents)
        {
            if (moneyBorders.Count + 1 != percents.Count)
                throw new BankException("Incorrect money borders and percents match");
            _moneyBorders = moneyBorders;
            _percents = percents;
        }
    }
}