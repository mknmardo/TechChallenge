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
    //This End to End Testing is using the Owin Self-Hosted API

    [TestClass]
    public class ApiIntegrationTests
    { 
        [Test]
        public void GetUnUsualBetWinners()
        {
            var result = new HttpHelper(new Uri(ConfigurationManager.AppSettings["SelfHostedUri"])).GetList<UnusualWinnerModel>("api/bet/unusualbetwinners")[0];

            Assert.IsNotNull(result);
            Assert.AreEqual("1",result.CustomerName);
            Assert.AreEqual((decimal)70,result.WinRate);
        }

        [Test]
        public void GetBetAnalysis()
        {
            var result = new HttpHelper(new Uri(ConfigurationManager.AppSettings["SelfHostedUri"])).GetList<BetAnalysisModel>("api/bet/betanalysis")[0];

            Assert.IsNotNull(result);
            Assert.AreEqual("1", result.Customer);
            Assert.AreEqual("11", result.Event);
            Assert.AreEqual(false,result.IsCurrentStakeTenTimesHigherThanAverage);
            Assert.AreEqual(false,result.IsCurrentStakeThirtyTimesHigherThanAverage);
            Assert.AreEqual(true,result.IsCustomerWinningAtUnusualRate);
            Assert.AreEqual("4",result.Participant);
            Assert.AreEqual((decimal)50,result.Stake);
            Assert.AreEqual((decimal)500,result.Win);
        }

        [Test]
        public void GetAnalysisResults()
        {
            var result = new HttpHelper(new Uri(ConfigurationManager.AppSettings["SelfHostedUri"])).Get<ResultsViewModel>("api/bet/analysisresults");

            Assert.IsNotNull(result.BetAnalysisList);
            Assert.IsNotNull(result.UnusualWinnersList);
        }


    }
}
