using Datos.Clientes;
using Datos.Empleados;
using Datos.Entregas;
using Modelos.Entregas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyectofinal.Controllers
{
    public class EntregasController : BaseController
    {
        private readonly EntregasDataContext _entregasDataContext;
        private readonly ClientesDataContext _clientesDataContext;
        private readonly EmpleadoDataContext _empleadoDataContext;
        public EntregasController()
        {
            _entregasDataContext = new EntregasDataContext();
            _clientesDataContext = new ClientesDataContext();
            _empleadoDataContext = new EmpleadoDataContext();
        }

        ///////////////////////////////////////////////////Entregas
        [VerifySession]
        public ActionResult Entregas()
        {
            var entregas = _entregasDataContext.ObtenerEntregas(0);
            //var clientes =_clientesDataContext.ObtenerClientes(0);
            //var empleados = _empleadoDataContext.ObtenerEmpleados(0);
            //var prioridades = _entregasDataContext.ObtenerPrioridad(0);
            //foreach (var item in entregas)
            //{
            //    item.Clientes = clientes;
            //    item.Prioridades = prioridades;
            //    item.Empleados = empleados;
            //}
            if (entregas.Count == 0) MensajeInfo = "No Hay datos";
            ViewData["GOOD"] = MensajeSucces;
            ViewData["ERROR"] = MensajeError;
            ViewData["INFO"] = MensajeInfo;
            LiberarMensajes();
            return View(entregas);
        }

        [VerifySession]
        public ActionResult InsertarEntrega()
        {
            var entrega = new Entrega()
            {
                Clientes = _clientesDataContext.ObtenerClientes(0),
                Empleados = _entregasDataContext.ObtenerEmpleadosDisponibles(),
                Prioridades = _entregasDataContext.ObtenerPrioridad(0)
            };
            return View(entrega);
        }

        [VerifySession, HttpPost]
        public ActionResult InsertarEntrega(Entrega entrega)
        {
            try
            {
                _entregasDataContext.InsertarEntrega(entrega);
                MensajeSucces = "Entrega Agregada";
            }
            catch (Exception ex)
            {
                MensajeError = ex.Message;
            }
            return RedirectToAction("Entregas");
        }

        [VerifySession]
        public ActionResult ModificarEntrega(int id)
        {
            try
            {
                var entregas = _entregasDataContext.ObtenerEntregas(id)[0];
                entregas.Clientes = _clientesDataContext.ObtenerClientes(0);
                entregas.Empleados = _entregasDataContext.ObtenerEmpleadosDisponibles();
                entregas.Prioridades = _entregasDataContext.ObtenerPrioridad(0);
                return View(entregas);
            }
            catch (Exception ex)
            {
                MensajeError = ex.Message;
                return RedirectToAction("Entregas");
            }
        }

        [VerifySession, HttpPost]
        public ActionResult ModificarEntrega(Entrega prioridad)
        {
            try
            {
                _entregasDataContext.ActualizarEntrega(prioridad);
                MensajeSucces = "Entrega Modificada";
            }
            catch (Exception ex)
            {
                MensajeError = ex.Message;
            }
            return RedirectToAction("Entregas");
        }

        [VerifySession]
        public ActionResult EliminarEntrega(int id)
        {
            try
            {
                _entregasDataContext.BorrarEntrega(id);
                MensajeSucces = "Entrega Borrada";
            }
            catch (Exception ex)
            {
                MensajeError = ex.Message;
            }
            return RedirectToAction("Entregas");
        }
        ///////////////////////////////////////////////////
        ///////////////////////////////////////////////////Prioridades
        [VerifySession]
        public ActionResult Prioridades()
        {
            var prioridades = _entregasDataContext.ObtenerPrioridad(0);
            if (prioridades.Count == 0) MensajeInfo = "No Hay datos";
            ViewData["GOOD"] = MensajeSucces;
            ViewData["ERROR"] = MensajeError;
            ViewData["INFO"] = MensajeInfo;
            LiberarMensajes();
            return View(prioridades);
        }

        [VerifySession]
        public ActionResult InsertarPrioridad()
        {
            return View();
        }

        [VerifySession, HttpPost]
        public ActionResult InsertarPrioridad(Prioridades prioridade)
        {
            try
            {
                _entregasDataContext.InsertaPrioridad(prioridade);
                MensajeSucces = "Priodirada Agregada";
            }
            catch (Exception ex)
            {
                MensajeError = ex.Message;
            }
            return RedirectToAction("Prioridades");
        }

        [VerifySession]
        public ActionResult ModificarPrioridad(int id)
        {
            try
            {
                var prioridad = _entregasDataContext.ObtenerPrioridad(id)[0];
                return View(prioridad);
            }
            catch (Exception ex)
            {
                MensajeError = ex.Message;
                return RedirectToAction("Prioridades");
            }
        }

        [VerifySession, HttpPost]
        public ActionResult ModificarPrioridad(Prioridades prioridad)
        {
            try
            {
                _entregasDataContext.ActualizarPrioridad(prioridad);
                MensajeSucces = "Priodirada Modificada";
            }
            catch (Exception ex)
            {
                MensajeError = ex.Message;
            }
            return RedirectToAction("Prioridades");
        }

        [VerifySession]
        public ActionResult EliminarPrioridad(int id)
        {
            try
            {
                _entregasDataContext.BorrarPrioridad(id);
                MensajeSucces = "Priodirada Borrada";
            }
            catch (Exception ex)
            {
                MensajeError = ex.Message;
            }
            return RedirectToAction("Prioridades");
        }



    }
}