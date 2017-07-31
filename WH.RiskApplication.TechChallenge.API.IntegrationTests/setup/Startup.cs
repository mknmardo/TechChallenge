using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft.Owin;
using Owin;

//[assembly: OwinStartup(typeof(WH.RiskApplication.TechChallenge.API.Startup))]

namespace WH.RiskApplication.TechChallenge.API.IntegrationTests
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            WH.RiskApplication.TechChallenge.API.WebApiConfig.Register(config);

            app.UseWebApi(config);
        }
    }
}
