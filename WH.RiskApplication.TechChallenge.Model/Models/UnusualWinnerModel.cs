using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WH.RiskApplication.TechChallenge.Common
{
    public class UnusualWinnerModel
    {
        public string CustomerName { get; set; }
        public decimal WinRate { get; set; }

        public UnusualWinnerModel()
        {
            this.CustomerName = string.Empty;
            this.WinRate = 0;
        }
    }
}
