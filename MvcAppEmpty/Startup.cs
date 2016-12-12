using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Mvc;
using Microsoft.Owin.Security.Cookies;

[assembly: OwinStartup(typeof(MvcAppEmpty.Startup))]

namespace MvcAppEmpty
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            //This filters all the classes and doesn't let any views open without logging in
            GlobalFilters.Filters.Add(new AuthorizeAttribute());

            CookieAuthenticationOptions options = new CookieAuthenticationOptions();
            options.AuthenticationType = "ApplicationCookie";
            options.LoginPath = new PathString("/Auth/Login");
            app.UseCookieAuthentication(options);
        }
    }
}
