using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft.Owin;
using Owin;
using Swashbuckle.Application;

[assembly: OwinStartup(typeof(WH.RiskApplication.TechChallenge.API.Startup))]

namespace WH.RiskApplication.TechChallenge.API
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            WebApiConfig.Register(config);

            app.UseWebApi(config);

            SwaggerConfig.Register(config);
        }
    }
}
