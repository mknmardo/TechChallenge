using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WH.RiskApplication.TechChallenge.Common
{
    public class BetDetailsModel
    {
        public string Customer { get; set; }
        public string Event { get; set; }
        public string Participant { get; set; }
        public decimal Stake { get; set; }
        public decimal Win { get; set; }
        public decimal ToWin { get; set; }


        public BetDetailsModel()
        {
            this.Customer = string.Empty;
            this.Event = string.Empty;
            this.Participant = string.Empty;
            this.Stake = 0;
            this.Win = 0;
            this.ToWin = 0;
        }
    }
}
