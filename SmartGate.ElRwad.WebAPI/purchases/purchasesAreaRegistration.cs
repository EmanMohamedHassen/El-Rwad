using System.Web.Mvc;

namespace SmartGate.ElRwad.WebAPI.Areas.purchases
{
    public class purchasesAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "purchases";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "purchases_default",
                "purchases/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}