using Datos.Empleados;
using Datos.Vehiculos;
using Modelos.Vehiculos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyectofinal.Controllers
{
    public class VehiculosController : BaseController
    {
        private readonly VehiculoDataContext _vehiculoDatos;
        private readonly EmpleadoDataContext _empleadoDataContext;
        public VehiculosController()
        {
            _vehiculoDatos = new VehiculoDataContext();
            _empleadoDataContext = new EmpleadoDataContext();
        }


        //////////////////////////////Vehiculo
        [VerifySession]
        public ActionResult Vehiculos()
        {
            var vehiculos = _vehiculoDatos.ObtenerVehiculos(0);
            if (vehiculos.Count == 0) MensajeInfo = "No Hay datos";
            ViewData["GOOD"] = MensajeSucces;
            ViewData["ERROR"] = MensajeError;
            ViewData["INFO"] = MensajeInfo;
            LiberarMensajes();
            foreach (var item in vehiculos)
            {
                item.Modelo = _vehiculoDatos.ObtenerModelos(item.ModeloID)[0].Nombre;
            }
            return View(vehiculos);
        }

        [VerifySession]
        public ActionResult InsertarVehiculo()
        {
            var vehiculo = new Vehiculo
            {
                Empleados = _empleadoDataContext.ObtenerEmpleados(0),
                Modelos = _vehiculoDatos.ObtenerModelos(0),
                Colores = _vehiculoDatos.ObtenerColores(0)
            };
            return View(vehiculo);
        }

        [VerifySession, HttpPost]
        public ActionResult InsertarVehiculo(Vehiculo vehiculo)
        {
            try
            {
                _vehiculoDatos.InsertarVehiculo(vehiculo);
                MensajeSucces = "Vehiculo Agregado";
            }
            catch (Exception ex)
            {
                MensajeError = ex.Message;
            }
            return RedirectToAction("Vehiculos");
        }

        [VerifySession]
        public ActionResult ModificarVehiculo(int id)
        {
            try
            {
                var vehiculo = _vehiculoDatos.ObtenerVehiculos(id)[0];
                vehiculo.Empleados = _empleadoDataContext.ObtenerEmpleados(0);
                vehiculo.Modelos = _vehiculoDatos.ObtenerModelos(0);
                vehiculo.Colores = _vehiculoDatos.ObtenerColores(0);
                return View(vehiculo);
            }
            catch (Exception ex)
            {
                MensajeError = ex.Message;
                return RedirectToAction("Vehiculos");
            }
        }

        [VerifySession, HttpPost]
        public ActionResult ModificarVehiculo(Vehiculo vehiculo)
        {
            try
            {
                _vehiculoDatos.ActualizarVehiculo(vehiculo);
                MensajeSucces = "Vehiculo Modificado";
            }
            catch (Exception ex)
            {
                MensajeError = ex.Message;
            }
            return RedirectToAction("Vehiculos");
        }

        [VerifySession]
        public ActionResult EliminarVehiculo(int id)
        {
            try
            {
                _vehiculoDatos.BorrarVehiculo(id);
                MensajeSucces = "Vehiculo Borrado";
            }
            catch (Exception ex)
            {
                MensajeError = ex.Message;
            }
            return RedirectToAction("Vehiculos");
        }

        //////////////////////////////

        //////////////////////////////Colores
        [VerifySession]
        public ActionResult Colores()
        {
            var colores = _vehiculoDatos.ObtenerColores(0);
            if (colores.Count == 0) MensajeInfo = "No Hay datos";
            ViewData["GOOD"] = MensajeSucces;
            ViewData["ERROR"] = MensajeError;
            ViewData["INFO"] = MensajeInfo;
            LiberarMensajes();
            return View(colores);
        }

        [VerifySession]
        public ActionResult InsertarColor()
        {
            return View();
        }

        [VerifySession, HttpPost]
        public ActionResult InsertarColor(Color color)
        {
            try
            {
                _vehiculoDatos.InsertarColor(color);
                MensajeSucces = "Color Agregado";
            }
            catch (Exception ex)
            {
                MensajeError = ex.Message;
            }
            return RedirectToAction("Colores");
        }

        [VerifySession]
        public ActionResult ModificarColor(int id)
        {
            try
            {
                var color = _vehiculoDatos.ObtenerColores(id)[0];
                return View(color);
            }
            catch (Exception ex)
            {
                MensajeError = ex.Message;
                return RedirectToAction("Colores");
            }
        }

        [VerifySession, HttpPost]
        public ActionResult ModificarColor(Color color)
        {
            try
            {
                _vehiculoDatos.ActualizarColor(color);
                MensajeSucces = "Color Modificado";
            }
            catch (Exception ex)
            {
                MensajeError = ex.Message;
            }
            return RedirectToAction("Colores");
        }

        [VerifySession]
        public ActionResult EliminarColor(int id)
        {
            try
            {
                _vehiculoDatos.BorrarColor(id);
                MensajeSucces = "Color Borrado";
            }
            catch (Exception ex)
            {
                MensajeError = ex.Message;
            }
            return RedirectToAction("Colores");
        }

        //////////////////////////////

        //////////////////////////////Marca
        [VerifySession]
        public ActionResult Marcas()
        {
            var marcas = _vehiculoDatos.ObtenerMarcas(0);
            if (marcas.Count == 0) MensajeInfo = "No Hay datos";
            ViewData["GOOD"] = MensajeSucces;
            ViewData["ERROR"] = MensajeError;
            ViewData["INFO"] = MensajeInfo;
            LiberarMensajes();
            return View(marcas);
        }

        [VerifySession]
        public ActionResult InsertarMarca()
        {
            return View();
        }

        [VerifySession, HttpPost]
        public ActionResult InsertarMarca(Marca marca)
        {
            try
            {
                _vehiculoDatos.InsertarMarca(marca);
                MensajeSucces = "Marca Agregada";
            }
            catch (Exception ex)
            {
                MensajeError = ex.Message;
            }
            return RedirectToAction("Marcas");
        }

        [VerifySession]
        public ActionResult ModificarMarca(int id)
        {
            try
            {
                var color = _vehiculoDatos.ObtenerMarcas(id)[0];
                return View(color);
            }
            catch (Exception ex)
            {
                MensajeError = ex.Message;
                return RedirectToAction("Marcas");
            }
        }

        [VerifySession, HttpPost]
        public ActionResult ModificarMarca(Marca marca)
        {
            try
            {
                _vehiculoDatos.ActualizarMarca(marca);
                MensajeSucces = "Marca Modificada";
            }
            catch (Exception ex)
            {
                MensajeError = ex.Message;
            }
            return RedirectToAction("Marcas");
        }

        [VerifySession]
        public ActionResult EliminarMarca(int id)
        {
            try
            {
                _vehiculoDatos.BorrarMarca(id);
                MensajeSucces = "Marca Borrada";
            }
            catch (Exception ex)
            {
                MensajeError = ex.Message;
            }
            return RedirectToAction("Marcas");
        }

        //////////////////////////////

        //////////////////////////////Modelo
        [VerifySession]
        public ActionResult Modelos()
        {
            var modelos = _vehiculoDatos.ObtenerModelos(0);
            if (modelos.Count == 0) MensajeInfo = "No Hay datos";
            ViewData["GOOD"] = MensajeSucces;
            ViewData["ERROR"] = MensajeError;
            ViewData["INFO"] = MensajeInfo;
            LiberarMensajes();
            return View(modelos);
        }

        [VerifySession]
        public ActionResult InsertarModelos()
        {
            var modelo = new Modelo();
            modelo.Marcas = _vehiculoDatos.ObtenerMarcas(0);
            return View(modelo);
        }

        [VerifySession, HttpPost]
        public ActionResult InsertarModelos(Modelo modelo)
        {
            try
            {
                _vehiculoDatos.InsertarModelo(modelo);
                MensajeSucces = "Modelo Agregado";
            }
            catch (Exception ex)
            {
                MensajeError = ex.Message;
            }
            return RedirectToAction("Modelos");
        }

        [VerifySession]
        public ActionResult ModificarModelo(int id)
        {
            try
            {
                var modelo = _vehiculoDatos.ObtenerModelos(id)[0];
                modelo.Marcas = _vehiculoDatos.ObtenerMarcas(0);
                return View(modelo);
            }
            catch (Exception ex)
            {
                MensajeError = ex.Message;
                return RedirectToAction("Modelos");
            }
        }

        [VerifySession, HttpPost]
        public ActionResult ModificarModelo(Modelo modelo)
        {
            try
            {
                _vehiculoDatos.ActualizarModelo(modelo);
                MensajeSucces = "Modelo Modificado";
            }
            catch (Exception ex)
            {
                MensajeError = ex.Message;
            }
            return RedirectToAction("Modelos");
        }

        [VerifySession]
        public ActionResult EliminarModelo(int id)
        {
            try
            {
                _vehiculoDatos.BorrarModelo(id);
                MensajeSucces = "Modelo Borrado";
            }
            catch (Exception ex)
            {
                MensajeError = ex.Message;
            }
            return RedirectToAction("Modelos");
        }

    }
}