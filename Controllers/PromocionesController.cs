using BLL;
using Peluqueria_canina_chichi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Peluqueria_canina_chichi.Controllers
{
    public class PromocionesController : Controller
    {
        clsPromociones promo = new clsPromociones();
        // GET: Promociones
        public ActionResult Index()
        {
            try
            {
                var datos = promo.ConsulatarPromociones();

                List<Promociones> ListaPromociones = new List<Promociones>();

                foreach (var item in datos)
                {
                    Promociones ObjPromo = new Promociones();

                    ObjPromo.CodPromocion = item.CodigoPromocion;
                    ObjPromo.FechaInicio = item.FechaInicio;
                    ObjPromo.FechaFin = item.FechaFin;
                    ObjPromo.Dia=item.Dia.GetValueOrDefault();
                    ObjPromo.Precio = Convert.ToInt32(item.Precio);
                    ObjPromo.Estado = item.Estado;
                    ObjPromo.CodProducto = item.CodigoProducto;

                    ListaPromociones.Add(ObjPromo);
                }

                return View(ListaPromociones);
            }
            catch (Exception ex)
            {

                throw;
            }

        }


        public ActionResult Editar(int id)
        {
            try
            {
                var dato = promo.ConsultarPromocion(id);

                Promociones objPromo = new Promociones();

                objPromo.CodPromocion = dato.CodigoPromocion;
                objPromo.FechaInicio = dato.FechaInicio;
                objPromo.FechaFin = dato.FechaFin;
                objPromo.Dia = dato.Dia.GetValueOrDefault();
                objPromo.Precio = dato.Precio.GetValueOrDefault();
                objPromo.Estado = dato.Estado;
                objPromo.CodProducto = dato.CodigoProducto;

                return View(objPromo);
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        [HttpPost]
        public ActionResult Editar(Promociones ObjPromo)
        {
            try
            {
                if (promo.ActualizarPromocion(ObjPromo.CodPromocion,ObjPromo.FechaInicio, ObjPromo.FechaFin, ObjPromo.Dia, ObjPromo.Precio,ObjPromo.Estado,ObjPromo.CodProducto))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public ActionResult Crear()
        {

            return View();

        }
        [HttpPost]
        public ActionResult Crear(Promociones objPromo)
        {
            try
            {
                if (promo.CrearPromocion(objPromo.FechaInicio,objPromo.FechaFin, objPromo.Dia, objPromo.Precio, objPromo.Estado, objPromo.CodProducto))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public ActionResult Eliminar(int id)
        {
            try
            {
                var dato = promo.ConsultarPromocion(id);

                Promociones objPromo = new Promociones();

                objPromo.CodProducto = dato.CodigoProducto;
                objPromo.FechaInicio = dato.FechaInicio;
                objPromo.FechaFin = dato.FechaFin;
                objPromo.Dia = dato.Dia.GetValueOrDefault();
                objPromo.Precio = dato.Precio.GetValueOrDefault();

                return View(objPromo);
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        [HttpPost]
        public ActionResult Eliminar(Promociones objPromo)
        {
            try
            {
                if (promo.EliminaPromocion(objPromo.CodPromocion))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
    }
