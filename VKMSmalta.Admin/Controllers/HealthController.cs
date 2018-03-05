using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using VKMSmalta.Admin.Models.Dto;

namespace VKMSmalta.Admin.Controllers
{
    public class HealthController : Controller
    {
        // GET
        public ActionResult Ping()
        {
            var response = new PingResponseDto();

            if (Assembly.GetExecutingAssembly()
                        .GetCustomAttributes(typeof(AssemblyFileVersionAttribute))
                        .FirstOrDefault() is AssemblyFileVersionAttribute versionAttribute)
            {
                response.ServiceVersion = versionAttribute.Version;
            }
            response.Uptime = DateTime.Now - Process.GetCurrentProcess().StartTime;

            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}