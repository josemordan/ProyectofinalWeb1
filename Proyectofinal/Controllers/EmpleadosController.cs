using Datos.Empleados;
using Datos.Vehiculos;
using Modelos.Empleados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyectofinal.Controllers
{
    public class EmpleadosController : BaseController
    {
        private readonly EmpleadoDataContext _empleadoDataContext;
        private readonly VehiculoDataContext _vehiculoDataContext;
        public EmpleadosController()
        {
            _empleadoDataContext = new EmpleadoDataContext();
            _vehiculoDataContext = new VehiculoDataContext();
        }

        /////////////////////////////////////////Empelado
        [VerifySession]
        public ActionResult Empleados()
        {
            var empleado = _empleadoDataContext.ObtenerEmpleados(0);
            if (empleado.Count == 0) MensajeInfo = "No Hay datos";
            ViewData["GOOD"] = MensajeSucces;
            ViewData["ERROR"] = MensajeError;
            ViewData["INFO"] = MensajeInfo;
            LiberarMensajes();
            return View(empleado);
        }

        [VerifySession]
        public ActionResult InsertarEmpleado()
        {
            var empleado = new Empleado();
            empleado.Cargos = _empleadoDataContext.ObtenerCargos(0);
            empleado.Departamentos = _empleadoDataContext.ObtenerDepartamento(0);

            return View(empleado);
        }

        [VerifySession, HttpPost]
        public ActionResult InsertarEmpleado(Empleado empleado)
        {
            try
            {
                _empleadoDataContext.InsertaEmpleado(empleado);
                MensajeSucces = "Empleado Agregado";
            }
            catch (Exception ex)
            {
                MensajeError = ex.Message;
            }
            return RedirectToAction("Empleados");
        }

        [VerifySession]
        public ActionResult ModificarEmpleado(int id)
        {
            try
            {
                var empleado = _empleadoDataContext.ObtenerEmpleados(id)[0];
                empleado.Cargos = _empleadoDataContext.ObtenerCargos(0);
                empleado.Departamentos = _empleadoDataContext.ObtenerDepartamento(0);
                return View(empleado);
            }
            catch (Exception ex)
            {
                MensajeError = ex.Message;
                return RedirectToAction("Empleados");
            }

        }

        [VerifySession, HttpPost]
        public ActionResult ModificarEmpleado(Empleado empleado)
        {
            try
            {
                _empleadoDataContext.ActualizarEmpleado(empleado);
                MensajeSucces = "Empleado Actualizado";
            }
            catch (Exception ex)
            {
                MensajeError = ex.Message;
            }
            return RedirectToAction("Empleados");
        }


        [VerifySession]
        public ActionResult EliminarEmpleado(int id)
        {
            try
            {
                _empleadoDataContext.BorrarEmpleado(id);
                MensajeSucces = "Empleado Borrado";
            }
            catch (Exception ex)
            {
                MensajeError = ex.Message;
            }
            return RedirectToAction("Empleados");
        }
        /////////////////////////////////////////
        /////////////////////////////////////////Departamento
        [VerifySession]
        public ActionResult Departamentos()
        {
            var departamento = _empleadoDataContext.ObtenerDepartamento(0);
            if (departamento.Count == 0) MensajeInfo = "No Hay datos";
            ViewData["GOOD"] = MensajeSucces;
            ViewData["ERROR"] = MensajeError;
            ViewData["INFO"] = MensajeInfo;
            LiberarMensajes();
            return View(departamento);
        }

        [VerifySession]
        public ActionResult InsertarDepartamento()
        {
            return View();
        }

        [VerifySession, HttpPost]
        public ActionResult InsertarDepartamento(Departamento departamento)
        {
            try
            {
                _empleadoDataContext.InsertaDepartamento(departamento);
                MensajeSucces = "Departamento Agregado";
            }
            catch (Exception ex)
            {
                MensajeError = ex.Message;
            }
            return RedirectToAction("Departamentos");
        }

        [VerifySession]
        public ActionResult ModificarDepartamento(int id)
        {
            try
            {
                var cargo = _empleadoDataContext.ObtenerDepartamento(id)[0];
                return View(cargo);
            }
            catch (Exception ex)
            {
                MensajeError = ex.Message;
                return RedirectToAction("Departamentos");
            }

        }

        [VerifySession, HttpPost]
        public ActionResult ModificarDepartamento(Departamento departamento)
        {
            try
            {
                _empleadoDataContext.ActualizarDepartamento(departamento);
                MensajeSucces = "Departamento Actualizado";
            }
            catch (Exception ex)
            {
                MensajeError = ex.Message;
            }
            return RedirectToAction("Departamentos");
        }


        [VerifySession]
        public ActionResult EliminarDepartamento(int id)
        {
            try
            {
                _empleadoDataContext.BorrarDepartamento(id);
                MensajeSucces = "Departamento Borrado";
            }
            catch (Exception ex)
            {
                MensajeError = ex.Message;
            }
            return RedirectToAction("Departamentos");
        }
        /////////////////////////////////////////
        /////////////////////////////////////////Cargo

        [VerifySession]
        public ActionResult Cargos()
        {
            var cargos = _empleadoDataContext.ObtenerCargos(0);
            if (cargos.Count == 0) MensajeInfo = "No Hay datos";
            ViewData["GOOD"] = MensajeSucces;
            ViewData["ERROR"] = MensajeError;
            ViewData["INFO"] = MensajeInfo;
            LiberarMensajes();
            return View(cargos);
        }

        [VerifySession]
        public ActionResult InsertarCargo()
        {
            return View();
        }

        [VerifySession, HttpPost]
        public ActionResult InsertarCargo(Cargo cargo)
        {
            try
            {
                _empleadoDataContext.InsertaCargo(cargo);
                MensajeSucces = "Cargo Agregado";
            }
            catch (Exception ex)
            {
                MensajeError = ex.Message;
            }
            return RedirectToAction("Cargos");
        }

        [VerifySession]
        public ActionResult ModificarCargo(int id)
        {
            try
            {
                var cargo = _empleadoDataContext.ObtenerCargos(id)[0];
                return View(cargo);
            }
            catch (Exception ex)
            {
                MensajeError = ex.Message;
                return RedirectToAction("Cargos");
            }

        }

        [VerifySession, HttpPost]
        public ActionResult ModificarCargo(Cargo cargo)
        {
            try
            {
                _empleadoDataContext.ActualizarCargo(cargo);
                MensajeSucces = "Cargo Actualizado";
            }
            catch (Exception ex)
            {
                MensajeError = ex.Message;
            }
            return RedirectToAction("Cargos");
        }


        [VerifySession]
        public ActionResult EliminarCargo(int id)
        {
            try
            {
                _empleadoDataContext.BorrarCargo(id);
                MensajeSucces = "Cargo Borrado";
            }
            catch (Exception ex)
            {
                MensajeError = ex.Message;
            }
            return RedirectToAction("Cargos");
        }

    }
}