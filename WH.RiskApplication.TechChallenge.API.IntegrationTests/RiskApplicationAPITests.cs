using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Microsoft.Owin.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using WH.RiskApplication.TechChallenge.Common;
using WH.RiskApplication.TechChallenge.Utils;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;


namespace WH.RiskApplication.TechChallenge.API.IntegrationTests
{
    [TestClass]
    public class RiskApplicationAPIIntegrationTests
    { 
        [Test]
        public void GetUnUsualBetWinners()
        {
            var result =new Response();
            result = new HttpHelper(new Uri(ConfigurationManager.AppSettings["SelfHostedUri"])).GetObjectList<Response>("api/bet/unusualbetwinners");

            Assert.IsNotNull(result);
        }

        [Test]
        public void GetBetAnalysis()
        {
            var result = new BetAnalysisModel();
            result = new HttpHelper(new Uri(ConfigurationManager.AppSettings["SelfHostedUri"])).GetObjectList<BetAnalysisModel>("api/bet/betanalysis");

            Assert.IsNotNull(result);
        }

        [Test]
        public void GetAnalysisResults()
        {
            var result = new ResultsViewModel();
            result = new HttpHelper(new Uri(ConfigurationManager.AppSettings["SelfHostedUri"])).GetObjectList<ResultsViewModel>("api/bet/analysisresults");

            Assert.IsNotNull(result);
        }


    }
}
