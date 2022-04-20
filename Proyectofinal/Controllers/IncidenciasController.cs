using Datos.Incidencias;
using Modelos.Incidencias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyectofinal.Controllers
{
    public class IncidenciasController : BaseController
    {
        private readonly IncidenciaDataContext _incidenciaDataContext;
        public IncidenciasController()
        {
            _incidenciaDataContext = new IncidenciaDataContext();
        }

        [VerifySession]
        public ActionResult Incidencias()
        {
            var incidencias = _incidenciaDataContext.ObtenerIncidencias(0);
            if (incidencias.Count == 0) MensajeInfo = "No Hay datos";
            ViewData["GOOD"] = MensajeSucces;
            ViewData["ERROR"] = MensajeError;
            ViewData["INFO"] = MensajeInfo;
            LiberarMensajes();
            return View(incidencias);
        }

        [VerifySession]
        public ActionResult InsertarIncidencia()
        {
            var incidencia = new Incidencia();
            incidencia.Vehiculos = _incidenciaDataContext.ObtenerVehiculosIncidencia();
            incidencia.Talleres = _incidenciaDataContext.ObtenerTalleres(0);
            //empleado.Departamentos = _empleadoDataContext.ObtenerDepartamento(0);

            return View(incidencia);
        }

        [VerifySession, HttpPost]
        public ActionResult InsertarIncidencia(Incidencia incidencia)
        {
            try
            {
                _incidenciaDataContext.InsertarIncidencia(incidencia);
                MensajeSucces = "Incidencia Agregada";
            }
            catch (Exception ex)
            {
                MensajeError = ex.Message;
            }
            return RedirectToAction("Incidencias");
        }

        [VerifySession]
        public ActionResult ModificarIncidencia(int id)
        {
            try
            {
                var incidencia = _incidenciaDataContext.ObtenerIncidencias(id)[0];
                incidencia.Vehiculos = _incidenciaDataContext.ObtenerVehiculosIncidencia();
                incidencia.Talleres = _incidenciaDataContext.ObtenerTalleres(0);
                return View(incidencia);
            }
            catch (Exception ex)
            {
                MensajeError = ex.Message;
                return RedirectToAction("Incidencias");
            }

        }

        [VerifySession, HttpPost]
        public ActionResult ModificarIncidencia(Incidencia incidencia)
        {
            try
            {
                _incidenciaDataContext.ActualizarIncidencia(incidencia);
                if (incidencia.Completada) _incidenciaDataContext.ActualizarIncidenciamatenimiento(incidencia.VehiculoID);
                MensajeSucces = "Incidencia Actualizada";
            }
            catch (Exception ex)
            {
                MensajeError = ex.Message;
            }
            return RedirectToAction("Incidencias");
        }


        [VerifySession]
        public ActionResult EliminarIncidencia(int id)
        {
            try
            {
                var incidencia = _incidenciaDataContext.ObtenerIncidencias(id)[0];
                _incidenciaDataContext.BorrarIncidencia(id);
                _incidenciaDataContext.ActualizarIncidenciamatenimiento(incidencia.VehiculoID);
                MensajeSucces = "Incidencia Borrada";
            }
            catch (Exception ex)
            {
                MensajeError = ex.Message;
            }
            return RedirectToAction("Incidencias");
        }

        //////////////////////////////////////////


        [VerifySession]
        public ActionResult Talleres()
        {
            var talleres = _incidenciaDataContext.ObtenerTalleres(0);
            if (talleres.Count == 0) MensajeInfo = "No Hay datos";
            ViewData["GOOD"] = MensajeSucces;
            ViewData["ERROR"] = MensajeError;
            ViewData["INFO"] = MensajeInfo;
            LiberarMensajes();
            return View(talleres);
        }

        [VerifySession]
        public ActionResult InsertarTaller()
        {
            return View();
        }

        [VerifySession, HttpPost]
        public ActionResult InsertarTaller(Taller taller)
        {
            try
            {
                _incidenciaDataContext.InsertarTaller(taller);
                MensajeSucces = "Taller Agregado";
            }
            catch (Exception ex)
            {
                MensajeError = ex.Message;
            }
            return RedirectToAction("Talleres");
        }

        [VerifySession]
        public ActionResult ModificarTaller(int id)
        {
            try
            {
                var taller = _incidenciaDataContext.ObtenerTalleres(id)[0];
                return View(taller);
            }
            catch (Exception ex)
            {
                MensajeError = ex.Message;
                return RedirectToAction("Talleres");
            }

        }

        [VerifySession, HttpPost]
        public ActionResult ModificarTaller(Taller taller)
        {
            try
            {
                _incidenciaDataContext.ActualizarTaller(taller);
                MensajeSucces = "Taller Actualizado";
            }
            catch (Exception ex)
            {
                MensajeError = ex.Message;
            }
            return RedirectToAction("Talleres");
        }


        [VerifySession]
        public ActionResult EliminarTaller(int id)
        {
            try
            {
                _incidenciaDataContext.BorrarTaller(id);
                MensajeSucces = "Taller Borrado";
            }
            catch (Exception ex)
            {
                MensajeError = ex.Message;
            }
            return RedirectToAction("Talleres");
        }

    }
}