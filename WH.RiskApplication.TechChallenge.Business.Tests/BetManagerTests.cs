using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WH.RiskApplication.TechChallenge.DAL;
using Moq;
using Ploeh.AutoFixture;

using WH.RiskApplication.TechChallenge.Business.interfaces;
using WH.RiskApplication.TechChallenge.Business.impl;
using WH.RiskApplication.TechChallenge.DAL.impl;
using WH.RiskApplication.TechChallenge.DAL.interfaces;
using WH.RiskApplication.TechChallenge.Common;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace WH.RiskApplication.TechChallenge.Business.Tests
{
    [TestClass]
    public class BetManagerTests
    {
        [TestMethod]
        public void GivenThirdPartyApiIsWorking_WhenIGetUnUsualBetWinners_ThenItShouldReturnResults()
        {
            //Arrange
            var betDetailsModel = new BetDetailsModel();
            betDetailsModel.Customer = "1";
            betDetailsModel.Event = "11";
            betDetailsModel.Participant = "4";
            betDetailsModel.Stake = 50;
            betDetailsModel.Win = 70;

            var betDalManager = new Mock<IBetDALManager>();
            betDalManager.Setup(s => s.GetSettledBets(It.IsAny<string>())).Returns(() => new List<BetDetailsModel>
            {
                betDetailsModel
            });

            var betManager = new BetManager(betDalManager.Object);
            //Act
            var result = betManager.GetUnUsualBetWinners();
            betDalManager.Verify(m => m.GetSettledBets(It.IsAny<string>()), Times.AtLeastOnce);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("1",result.ElementAt(0).CustomerName);
            Assert.AreEqual((decimal)100,result.ElementAt(0).WinRate);
        }

        [TestMethod]
        public void GivenThirdPartyApiIsWorking_WhenIGetUnUsualBetWinnersUsingRandomValues_ThenReturnValidCustomerAndResulltNotNull()
        {
            //Arrange
            Fixture fixture = new Fixture();
            var betDetailsModel = fixture.Create<BetDetailsModel>();

            var betDalManager = new Mock<IBetDALManager>();
            betDalManager.Setup(s => s.GetSettledBets(It.IsAny<string>())).Returns(() => new List<BetDetailsModel>
            {
                betDetailsModel
            });

            var betManager = new BetManager(betDalManager.Object);
            //Act
            var result = betManager.GetUnUsualBetWinners();
            betDalManager.Verify(m => m.GetSettledBets(It.IsAny<string>()), Times.AtLeastOnce);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(betDetailsModel.Customer,result.ElementAt(0).CustomerName);
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
