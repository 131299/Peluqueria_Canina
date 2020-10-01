using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Peluqueria_canina_chichi.Models;

namespace Peluqueria_canina_chichi.Controllers
{
    public class ProductosController : Controller
    {
        clsProductos producto = new clsProductos();

        // GET: Productos
        public ActionResult Index()
        {
            try
            {
                var datos = producto.ConsultarProductos();

                List<Productos> ListaProductos = new List<Productos>();
                //HttpPostedFileBase filebase = Request.Files[0];
                //WebImage image = new WebImage(filebase.InputStream);

                foreach (var item in datos)
                {
                    //Byte[] b= new Byte[10];
                    Productos objProducto = new Productos();
                    objProducto.CodProducto = item.CodigoProducto;
                    objProducto.Nombre = item.Nombre;
                    objProducto.Descripcion = item.Descripción;
                    objProducto.Foto = item.Foto.ToArray();
                    objProducto.Marca = item.Marca;
                    objProducto.Precio = Convert.ToInt32(item.Precio);
                    objProducto.Iva = Convert.ToInt32(item.Iva); 
                    objProducto.Stock = item.Stock;
                    objProducto.CodProovedor = item.CodigoProveedor;
                    objProducto.CodCategoria = item.CodigoCategoria;
                    ListaProductos.Add(objProducto);
                }

                return View(ListaProductos);
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
                var dato = producto.ConsultarProducto(id);

                Productos objProducto = new Productos();
                objProducto.CodProducto = dato.CodigoProducto;
                objProducto.Nombre = dato.Nombre;
                objProducto.Descripcion = dato.Descripción;
                objProducto.Foto = dato.Foto.ToArray();
                objProducto.Marca = dato.Marca;
                objProducto.Precio = Convert.ToInt32(dato.Precio);
                objProducto.Iva = Convert.ToInt32(dato.Iva); ;
                objProducto.Stock = dato.Stock;
                objProducto.CodProovedor = dato.CodigoProveedor;
                objProducto.CodCategoria = dato.CodigoCategoria;

                return View(objProducto);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        [HttpPost]
        public ActionResult Editar(Productos objProducto, HttpPostedFileBase UploadImage)
        {
            try
            {
                if (UploadImage != null && UploadImage.ContentLength > 0)
                {
                    byte[] ImagenData = null;
                    using (var imagen = new BinaryReader(UploadImage.InputStream))
                    {
                        ImagenData = imagen.ReadBytes(UploadImage.ContentLength);
                    }
                    objProducto.Foto = ImagenData;
                }
                if (producto.ActualizarProducto(objProducto.CodProducto, objProducto.Nombre, objProducto.Descripcion, objProducto.Foto, objProducto.Marca, 
                    objProducto.Precio, objProducto.Iva, objProducto.Stock, objProducto.Estado, objProducto.CodProovedor, objProducto.CodCategoria))
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
        public ActionResult Crear(Productos objProducto, HttpPostedFileBase UploadImage)
        {

            try
            {
                if (UploadImage != null && UploadImage.ContentLength > 0)
                {
                    byte[] ImagenData = null;
                    using (var imagen = new BinaryReader(UploadImage.InputStream))
                    {
                        ImagenData = imagen.ReadBytes(UploadImage.ContentLength);
                    }
                    objProducto.Foto = ImagenData;
                }
                if (producto.AgregarProducto(objProducto.Nombre, objProducto.Descripcion, objProducto.Foto, objProducto.Marca,
                    objProducto.Precio, objProducto.Iva, objProducto.Stock, objProducto.Estado, objProducto.CodProovedor, objProducto.CodCategoria))
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
                var dato = producto.ConsultarProducto(id);

                Productos objProducto = new Productos();

                objProducto.CodProducto = dato.CodigoProducto;
                objProducto.Nombre = dato.Nombre;
                objProducto.Descripcion = dato.Descripción;
                objProducto.Foto = dato.Foto.ToArray();
                objProducto.Marca = dato.Marca;
                objProducto.Precio = Convert.ToInt32(dato.Precio);
                objProducto.Iva = Convert.ToInt32(dato.Iva); ;
                objProducto.Stock = dato.Stock;
                objProducto.CodProovedor = dato.CodigoProveedor;
                objProducto.CodCategoria = dato.CodigoCategoria;


                return View(objProducto);
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        [HttpPost]
        public ActionResult Eliminar(Productos objProducto)
        {
            try
            {
                if (producto.EliminarProductos(objProducto.CodProducto))
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