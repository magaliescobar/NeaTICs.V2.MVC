using System.Web.Mvc;

namespace NeaTICs_v2.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                name: "Root", 
                url: "{culture}/{controller}/{action}/{id}",
                defaults: new { culture = "es", controller = "Home", action = "Index" }
            );

            context.MapRoute(
                name: "Admin_default",
                url: "Admin/{controller}/{action}/{id}",
                defaults: new { culture = string.Empty, controller = "Home", action = "Login", id = UrlParameter.Optional },
                namespaces: new[] { "NeaTICs_v2.Areas.Admin.Controllers" }
            );
        }
    }
}
