using System.Collections.Generic;

namespace Banks.Classes
{
    public class CentralBank
    {
        private List<Bank> _banks;

        public CentralBank()
        {
            _banks = new List<Bank>();
        }

        public Bank RegisterNewBank()
        {
            var newBank = new Bank();
            _banks.Add(newBank);
            return newBank;
        }
    }
}