using System.Web.Mvc;

namespace SmartGate.ElRwad.WebAPI.Areas.MainCoding
{
    public class MainCodingAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "MainCoding";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "MainCoding_default",
                "MainCoding/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}