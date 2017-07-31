using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WH.RiskApplication.TechChallenge.Common
{
    public class BetAnalysisModel
    {
        public string Customer { get; set; }
        public string Event { get; set; }
        public string Participant { get; set; }
        public decimal Stake { get; set; }
        public decimal Win { get; set; }
        public bool IsCurrentWinningOnRiskAmount { get; set; }
        public bool IsCurrentStakeTenTimesHigherThanAverage { get; set; }
        public bool IsCurrentStakeThirtyTimesHigherThanAverage { get; set; }
        public bool IsCustomerWinningAtUnusualRate { get; set; }


        public BetAnalysisModel()
        {
            this.Customer = string.Empty;
            this.Event = string.Empty;
            this.Participant = string.Empty;
            this.Stake = 0;
            this.Win = 0;
            this.IsCurrentStakeThirtyTimesHigherThanAverage = false;
            this.IsCurrentStakeTenTimesHigherThanAverage = false;
            this.IsCurrentWinningOnRiskAmount = false;
            this.IsCustomerWinningAtUnusualRate = false;
        }
    }
}
