using System.Web;
using System.Web.Mvc;

namespace WH.RiskApplication.TechChallenge.API
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
