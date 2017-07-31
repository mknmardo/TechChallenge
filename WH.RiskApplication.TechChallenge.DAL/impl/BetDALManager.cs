using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WH.RiskApplication.TechChallenge.Utils;
using WH.RiskApplication.TechChallenge.Common;
using WH.RiskApplication.TechChallenge.DAL.interfaces;

namespace WH.RiskApplication.TechChallenge.DAL.impl
{
    public class BetDALManager:IBetDALManager
    {
        public IEnumerable<BetDetailsModel> GetSettledBets(string endpoint)
        {
           var settledBetList = new List<BetDetailsModel>();
           settledBetList = new HttpHelper(new Uri(ConfigurationManager.AppSettings["BaseAddress"])).GetList<BetDetailsModel>(endpoint);
           return settledBetList;
        }

        public IEnumerable<BetDetailsModel> GetUnSettledBets(string endpoint)
        {
            var unSettledBetList = new List<BetDetailsModel>();
            unSettledBetList = new HttpHelper(new Uri(ConfigurationManager.AppSettings["BaseAddress"])).GetList<BetDetailsModel>(endpoint);
            return unSettledBetList;
        }
    }
}
