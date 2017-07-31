using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WH.RiskApplication.TechChallenge.Common;

namespace WH.RiskApplication.TechChallenge.Business.interfaces
{
    public interface IBetManager
    {
        IEnumerable<UnusualWinnerModel> GetUnUsualBetWinners();
        IEnumerable<BetAnalysisModel> GetBetAnalysis();
        ResultsViewModel GetAnalysisResults();
    }
}
