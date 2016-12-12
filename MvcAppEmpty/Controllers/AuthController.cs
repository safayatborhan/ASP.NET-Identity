using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcAppEmpty.Models;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System.Security.Claims;

namespace MvcAppEmpty.Controllers
{
    [AllowAnonymous]   //This let us to access without login. as there is full project login filter in the startup class
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if(model.Email.Length > 0 && model.Password.Length > 0)
            {
                //credentials ar ok. sign in
                /*
                 * get the authentication manager
                 * create a claim
                 * create claims identity
                 * sign in be manager and claims identity
                 */

                IOwinContext context = Request.GetOwinContext();
                IAuthenticationManager manager = context.Authentication;

                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Email, model.Email));    //email claims
                claims.Add(new Claim(ClaimTypes.Name, "Zisan"));
                claims.Add(new Claim("Test", "Test@" + DateTime.Now));  //custom claims
                ClaimsIdentity identity = new ClaimsIdentity(claims: claims, authenticationType: "ApplicationCookie");
                manager.SignIn(identities: identity);
                return Redirect("/");    //If all is okay, then it will go to the default page
            }
            return View(model);
        }

        [Authorize]
        public ActionResult LogOut()
        {
            IOwinContext context = Request.GetOwinContext();
            IAuthenticationManager manager = context.Authentication;

            manager.SignOut();
            return Redirect("/");
        }
    }
}