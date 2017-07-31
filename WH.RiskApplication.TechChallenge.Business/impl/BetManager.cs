using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using WH.RiskApplication.TechChallenge.Business.interfaces;
using WH.RiskApplication.TechChallenge.Common;
using WH.RiskApplication.TechChallenge.DAL.interfaces;

namespace WH.RiskApplication.TechChallenge.Business.impl
{
    public class BetManager:IBetManager
    {
        private IBetDALManager _betDalManager;

        public BetManager(IBetDALManager betDalManager)
        {
            _betDalManager = betDalManager;
        }


        public IEnumerable<UnusualWinnerModel> GetUnUsualBetWinners()
        {
            var groupedListByCustomer = this._betDalManager.GetSettledBets(ConfigurationManager.AppSettings["SettledBet_Endpoint"]).ToList()
                .GroupBy(x => x.Customer)
                .Select(x => new UnusualWinnerModel
                {
                    CustomerName = x.Key,
                    WinRate = (((decimal)x.Count(y => y.Win > 0) / x.Count()) * 100)
                });

            return groupedListByCustomer
                .Where(x => x.WinRate > 60)
                .ToList();
        }


        public IEnumerable<BetAnalysisModel> GetBetAnalysis()
        {
            var betAnalysisList = new List<BetAnalysisModel>();

            IEnumerable<BetDetailsModel> settledBetDataList =  this._betDalManager.GetSettledBets(ConfigurationManager.AppSettings["SettledBet_Endpoint"]).ToList();
            IEnumerable<BetDetailsModel> unsettledBetDataList = this._betDalManager.GetUnSettledBets(ConfigurationManager.AppSettings["UnSettledBet_Endpoint"]).ToList();
            List<string> customerListUnsettled = unsettledBetDataList?
            .Select(c => c.Customer)
            .Distinct()
            .ToList();

            var unusualWinnersList = GetUnUsualBetWinners();

            foreach (string customer in customerListUnsettled)
            {
                decimal numberOfBetsMade = settledBetDataList?
                    .Where(c => c.Customer == customer)
                    .Count() ?? 0;

                decimal averageStake = (settledBetDataList?
                    .Where(c => c.Customer == customer)
                    .Sum(c => c.Stake) / numberOfBetsMade) ?? 0;

                var unusualWinnersNameList = unusualWinnersList?.Select(x => x.CustomerName);

                foreach (var unsettledBet in unsettledBetDataList?.Where(c => c.Customer == customer))
                {
                    var newBetAnalysis = new BetAnalysisModel
                    {
                        Customer = unsettledBet.Customer,
                        Event = unsettledBet.Event,
                        Participant = unsettledBet.Participant,
                        Stake = unsettledBet.Stake,
                        Win = unsettledBet.ToWin,

                        IsCurrentStakeTenTimesHigherThanAverage = IsTenTimesHigherThanAverage(averageStake, unsettledBet.Stake),
                        IsCurrentStakeThirtyTimesHigherThanAverage = IsThirtyTimesHigherThanAverage(averageStake, unsettledBet.Stake),
                        IsCurrentWinningOnRiskAmount = IsRisky(unsettledBet.ToWin),
                        IsCustomerWinningAtUnusualRate = unusualWinnersNameList?.Contains(unsettledBet.Customer) ?? false
                    };

                    betAnalysisList.Add(newBetAnalysis);
                }
            }
            return betAnalysisList;
        }


        public ResultsViewModel GetAnalysisResults()
        {
            var analysisResults = new ResultsViewModel();

            analysisResults.BetAnalysisList = GetBetAnalysis();
            analysisResults.UnusualWinnersList = GetUnUsualBetWinners();

            return analysisResults;
        }


        private bool IsThirtyTimesHigherThanAverage(decimal averageStake , decimal stake)
        {
            return stake > (averageStake * 30);
        }

        private bool IsTenTimesHigherThanAverage(decimal averageStake, decimal stake)
        {
            return stake > (averageStake * 10);
        }

        private bool IsRisky(decimal stakeAmount)
        {
            return stakeAmount >= 1000;
        }

     }
}
