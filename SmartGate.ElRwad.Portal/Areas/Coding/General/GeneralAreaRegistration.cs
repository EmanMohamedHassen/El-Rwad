﻿using System.Web.Mvc;

namespace SmartGate.ElRwad.Portal.Areas.Coding.General
{
    public class GeneralAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "General";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "General_default",
                "General/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}