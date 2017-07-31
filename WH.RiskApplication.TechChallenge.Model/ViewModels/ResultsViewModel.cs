using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WH.RiskApplication.TechChallenge.Common
{
    public class ResultsViewModel
    {
        public IEnumerable<BetAnalysisModel> BetAnalysisList { get; set; }
        public IEnumerable<UnusualWinnerModel> UnusualWinnersList { get; set; }
    }
}
