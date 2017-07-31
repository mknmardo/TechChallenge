using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;
using System.Configuration;
using Microsoft.Owin.Hosting;

namespace WH.RiskApplication.TechChallenge.API.IntegrationTests
{
    [SetUpFixture]
    public class GlobalSetup
    {
        private IDisposable _server;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            bool selfHosted = Convert.ToBoolean(ConfigurationManager.AppSettings["selfHosted"]);

            if (selfHosted)
            {
                string baseAddress = ConfigurationManager.AppSettings["SelfHostedUri"];

                _server = WebApp.Start<Startup>(url: baseAddress);
            }
        }

        [OneTimeTearDown]
        public void OnTimeTeardown()
        {
            try
            {
                _server?.Dispose();
            }
            catch (Exception)
            { }

            _server = null;
        }
    }
}
