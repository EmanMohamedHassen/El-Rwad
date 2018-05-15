using System.Web.Mvc;

namespace SmartGate.ElRwad.Portal.Areas.Corporation
{
    public class CorporationAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Corporation";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Corporation_default",
                "Corporation/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}