using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace MvcAutenticacao
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_PostAuthenticateRequest(object sender, EventArgs e)
        {
            if (FormsAuthentication.CookiesSupported)
            {
                if (Request.Cookies[FormsAuthentication.FormsCookieName] != null)
                {                    
                    string usuario = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name;


                    // Obtem do banco de dados as roles do usuáro logado pelo login
                    string roles = "admin";
                    

                    //Let us set the Pricipal with our user specific details
                    HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(
                      new System.Security.Principal.GenericIdentity(usuario, "Forms"), roles.Split(';'));
                }
            }
        }
    }
}
