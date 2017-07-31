using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WH.RiskApplication.TechChallenge.DAL;
using Moq;

using WH.RiskApplication.TechChallenge.Business.interfaces;
using WH.RiskApplication.TechChallenge.Business.impl;
using WH.RiskApplication.TechChallenge.DAL.impl;
using WH.RiskApplication.TechChallenge.DAL.interfaces;
using WH.RiskApplication.TechChallenge.Common;
using System.Configuration;

namespace WH.RiskApplication.TechChallenge.Business.Tests
{
    [TestClass]
    public class BetManagerTests
    {
        [TestMethod]
        public void GivenThirdPartyApiIsWorking_WhenIGetUnUsualBetWinners_ThenItShouldReturnResults()
        {
            //Arrange
            var betDalManager = new Mock<IBetDALManager>();        
            var betManager = new BetManager(betDalManager.Object);
            var result = new List<UnusualWinnerModel>();

            //Act
            Action action = () =>
            {
                result = betManager.GetUnUsualBetWinners().ToList();
                betDalManager.Verify(m => m.GetSettledBets(It.IsAny<string>()), Times.AtLeastOnce);
            };

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GivenThirdPartyApiIsWorking_WhenIGetBetAnalysis_ThenItShouldReturnResults()
        {
            //Arrange
            var betDalManager = new Mock<IBetDALManager>();
            var betManager = new BetManager(betDalManager.Object);
            var result = new List<BetAnalysisModel>();

            //Act
            Action action = () =>
            {
                result = betManager.GetBetAnalysis().ToList();
                betDalManager.Verify(m => m.GetSettledBets(It.IsAny<string>()), Times.AtLeastOnce);
                betDalManager.Verify(m => m.GetUnSettledBets(It.IsAny<string>()), Times.AtLeastOnce);
            };

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GivenThirdPartyApiIsWorking_WhenIGetAnalysisResults_ThenItShouldReturnResults()
        {
            //Arrange
            var betDalManager = new Mock<IBetDALManager>();
            var betManager = new BetManager(betDalManager.Object);
            var result = new ResultsViewModel();

            //Act
            Action action = () =>
            {
                result = betManager.GetAnalysisResults();
                betDalManager.Verify(m => m.GetSettledBets(It.IsAny<string>()), Times.AtLeastOnce);
                betDalManager.Verify(m => m.GetUnSettledBets(It.IsAny<string>()), Times.AtLeastOnce);
            };

            //Assert
            Assert.IsNotNull(result);
        }
    }
}
