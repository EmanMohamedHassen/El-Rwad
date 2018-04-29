using System.Web.Mvc;

namespace SmartGate.ElRwad.WebAPI.Areas.Transportation
{
    public class TransportationAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Transportation";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Transportation_default",
                "Transportation/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}