using Datos.Clientes;
using Modelos.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyectofinal.Controllers
{
    public class ClientesController : BaseController
    {
        private readonly ClientesDataContext _clientesDataContext;
        public ClientesController()
        {
            _clientesDataContext = new ClientesDataContext();
        }

        [VerifySession]
        public ActionResult Clientes()
        {
            var clientes = _clientesDataContext.ObtenerClientes(0);
            if (clientes.Count == 0) MensajeInfo = "No Hay datos";
            ViewData["GOOD"] = MensajeSucces;
            ViewData["ERROR"] = MensajeError;
            ViewData["INFO"] = MensajeInfo;
            LiberarMensajes();
            return View(clientes);
        }

        [VerifySession]
        public ActionResult InsertarCliente()
        {

            return View();
        }

        [VerifySession, HttpPost]
        public ActionResult InsertarCliente(Cliente cliente)
        {
            try
            {
                _clientesDataContext.InsertarClientes(cliente);
                MensajeSucces = "Cliente Agregado";
            }
            catch (Exception ex)
            {
                MensajeError = ex.Message;
            }
            return RedirectToAction("Clientes");
        }

        [VerifySession]
        public ActionResult ModificarCliente(int id)
        {
            try
            {
                var cliente = _clientesDataContext.ObtenerClientes(id)[0];
                return View(cliente);
            }
            catch (Exception ex)
            {
                MensajeError = ex.Message;
                return RedirectToAction("Clientes");
            }

        }

        [VerifySession, HttpPost]
        public ActionResult ModificarCliente(Cliente cliente)
        {
            try
            {
                _clientesDataContext.ActualizarClientes(cliente);
                MensajeSucces = "Cliente Actualizad0";
            }
            catch (Exception ex)
            {
                MensajeError = ex.Message;
            }
            return RedirectToAction("Clientes");
        }


        [VerifySession]
        public ActionResult EliminarCliente(int id)
        {
            try
            {
                _clientesDataContext.BorrarClientes(id);
                MensajeSucces = "Incidencia Borrada";
            }
            catch (Exception ex)
            {
                MensajeError = ex.Message;
            }
            return RedirectToAction("Clientes");
        }
    }
}