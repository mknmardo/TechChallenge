using System.Web.Http;
using WebActivatorEx;
using WH.RiskApplication.TechChallenge;
using Swashbuckle.Application;

namespace WH.RiskApplication.TechChallenge
{
    public class SwaggerConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            config
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "WH.RiskApplication.TechChallenge.API");
                    })
                .EnableSwaggerUi(c =>
                    {               
                        c.DocExpansion(DocExpansion.List);
                    });
        }
    }
}
