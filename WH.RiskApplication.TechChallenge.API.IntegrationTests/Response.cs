using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WH.RiskApplication.TechChallenge.Common;

namespace WH.RiskApplication.TechChallenge.API.IntegrationTests
{
    public class Response
    {
        public IEnumerable<UnusualWinnerModel> UnusualWinner { get; set; }
    }
}
