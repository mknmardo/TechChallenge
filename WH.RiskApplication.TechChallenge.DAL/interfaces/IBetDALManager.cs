using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WH.RiskApplication.TechChallenge.Common;

namespace WH.RiskApplication.TechChallenge.DAL.interfaces
{
    public interface IBetDALManager
    {
        IEnumerable<BetDetailsModel> GetSettledBets(string endpoint);
        IEnumerable<BetDetailsModel> GetUnSettledBets(string endpoint);
    }
}
