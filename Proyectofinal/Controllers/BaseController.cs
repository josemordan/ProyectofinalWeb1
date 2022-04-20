using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyectofinal.Controllers
{
    public class BaseController : Controller
    {
        public static string MensajeError { get; set; }
        public static string MensajeSucces { get; set; }
        public static string MensajeInfo { get; set; }

        public void LiberarMensajes()
        {
            MensajeSucces = null;
            MensajeError = null;
            MensajeInfo = null;
        }
    }
}