using MvcAutenticacao.Models;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcAutenticacao.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            var usuario = new UsuarioModel();
            return View(usuario);
        }

        [HttpPost]
        public ActionResult Index(UsuarioModel formUsuario, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                // Neste ponto, deveriamos conectar no banco de dados e validar se o usuario está 
                // cadastrado e ativo e se a senha é valida
                // Por enquanto a nossa aplicação só vai funcionar para o usuario tiago com a senha futuroprogramador.
                var usuarioValido = formUsuario.Usuario == "tiago" && formUsuario.Senha == "futuroprogramador";

                if (usuarioValido)
                {
                    FormsAuthentication.SetAuthCookie(formUsuario.Usuario, false);

                    if (Url.IsLocalUrl(returnUrl) 
                        && returnUrl.Length > 1
                        && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//")
                        && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Usuário e/ou Senha Inválidos, tente efetuar login novamente!");
                }
            }        

            return View(formUsuario);
        }

        [HttpPost]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }    
}