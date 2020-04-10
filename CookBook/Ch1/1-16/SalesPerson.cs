using System;
using System.Collections.Generic;
using System.Text;

namespace CookBook.Ch1
{
    class SalesPerson
    {
        // private
        decimal _commission;
        // public 
        public string Name { get; set; }
        public decimal AnnualQuota { get; set; }
        public decimal CommissionRate { get; set; }
        public decimal Commission
        {
            get { return _commission; }
            set
            {
                _commission = value;
                TotalCommission += _commission;
            }
        }
        public decimal TotalCommission { get; private set; }

        public SalesPerson() { }
        public SalesPerson(string name, decimal annualQuota, decimal commissionRate)
        {
            Name = name;
            AnnualQuota = annualQuota;
            CommissionRate = commissionRate;
        }
    }
}
