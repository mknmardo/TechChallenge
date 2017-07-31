using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WH.RiskApplication.TechChallenge.Business.interfaces;
using WH.RiskApplication.TechChallenge.Business.impl;
using WH.RiskApplication.TechChallenge.DAL.impl;
using WH.RiskApplication.TechChallenge.Common;

namespace WH.RiskApplication.TechChallenge.API.Controllers
{
    [RoutePrefix("api/bet")]
    public class BetController : ApiController
    {
        [HttpGet]
        [Route("unusualbetwinners")]
        public IEnumerable<UnusualWinnerModel> GetUnUsualBetWinners()
        {
            IBetManager betManager = new BetManager(new BetDALManager());
            return betManager.GetUnUsualBetWinners();
        }

        [HttpGet]
        [Route("betanalysis")]
        public IEnumerable<BetAnalysisModel> GetBetAnalysis()
        {
            IBetManager betManager = new BetManager(new BetDALManager());
            return betManager.GetBetAnalysis();
        }

        [HttpGet]
        [Route("analysisresults")]
        public ResultsViewModel Test3()
        {
            IBetManager betManager = new BetManager(new BetDALManager());
            return betManager.GetAnalysisResults();
        }
    }
}
