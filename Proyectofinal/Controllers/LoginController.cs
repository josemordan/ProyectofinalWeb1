using Datos.Usuarios;
using Proyectofinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyectofinal.Controllers
{
    public class LoginController : Controller
    {
        private readonly UsuarioContext _usuarioLogica;

        public LoginController()
        {
            _usuarioLogica = new UsuarioContext();
        }
        // GET: Login
        [VerifySession]
        public ActionResult Login()
        {
            //_usuarioLogica.Consultar
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel login)
        {
            try
            {
                if (string.IsNullOrEmpty(login.Clave) || string.IsNullOrEmpty(login.Usuario))
                {
                    ViewData["ERROR"] = "Usuario o Contraseña vacios, favor completar los campos.";
                    return View();
                }
                int idUsuario = _usuarioLogica.Autentica(login.Usuario, login.Clave);
                if (idUsuario.Equals(0))
                {
                    ViewData["ERROR"] = "Usuario o Contraseña Incorrecto";
                    return View();
                }
                var usuario = _usuarioLogica.ConsultarUsuario(idUsuario);
                LoginHelper.NombreUsuario = usuario[0].Nombre;
                LoginHelper.ID = usuario[0].UsuarioId;

                Session["Usuario"] = LoginHelper.NombreUsuario;
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewData["ERROR"] = "Error consultando usuario";
                return View();
            }
        }

        public ActionResult Logout()
        {
            Session["Usuario"] = null;
            return RedirectToAction("Login");
        }
    }
}