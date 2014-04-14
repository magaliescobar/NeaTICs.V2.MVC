using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading;
using NeaTICs_v2.Helpers;

namespace NeaTICs_v2.Controllers
{
    public class BaseController : Controller
    {
        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            string cultureName = RouteData.Values["culture"] as string;

            if (cultureName == null)
            {
                cultureName = Request.UserLanguages != null && Request.UserLanguages.Length > 0 ? Request.UserLanguages[0] : null;
            }

            cultureName = CultureHelper.GetImplementedCulture(cultureName);

            if (RouteData.Values["culture"] as string != cultureName)
            {
                RouteData.Values["culture"] = cultureName.ToLowerInvariant();
                Response.RedirectToRoute(RouteData.Values);
            }


            // Modificamos la cultura del hilo actual
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cultureName);
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;

            return base.BeginExecuteCore(callback, state);
        }
    }
}
