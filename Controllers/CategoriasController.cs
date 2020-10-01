using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using BLL;
using DAL;
using Peluqueria_canina_chichi.Models;

namespace Peluqueria_canina_chichi.Controllers
{
    
    public class CategoriasController : Controller
    {
        clsCategoria categoria = new clsCategoria();

        // GET: Categorias
        public ActionResult Index()
        {
            try
            {
                var datos = categoria.ConsultaCategorias();

                List<Categoria> ListaCategorias = new List<Categoria>();
                //HttpPostedFileBase filebase = Request.Files[0];
                //WebImage image = new WebImage(filebase.InputStream);

                foreach (var item in datos)
                {
                    //Byte[] b= new Byte[10];
                    Categoria objCategoria = new Categoria();
                    objCategoria.CodCategoria = item.CodigoCategoria;
                    objCategoria.Descripcion = item.Descripción;
                    objCategoria.Foto = item.Foto.ToArray();
                    objCategoria.Estado = item.Estado;
                    ListaCategorias.Add(objCategoria);
                }

                return View(ListaCategorias);
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
                var dato = categoria.ConsultarCategoria(id);

                Categoria objCategoria = new Categoria();
               

                objCategoria.CodCategoria = dato.CodigoCategoria;
                objCategoria.Descripcion = dato.Descripción;
                objCategoria.Foto = dato.Foto.ToArray();
                objCategoria.Estado = dato.Estado;
               
                return View(objCategoria);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        [HttpPost]
        public ActionResult Editar(Categoria objCategoria, HttpPostedFileBase UploadImage)
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
                    objCategoria.Foto = ImagenData;
                }
                if (categoria.ActualizarCategoria(objCategoria.CodCategoria, objCategoria.Descripcion, objCategoria.Foto, objCategoria.Estado))
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
        public ActionResult Crear(Categoria objCategoria,HttpPostedFileBase UploadImage)
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
                    objCategoria.Foto = ImagenData;
                }
                if (categoria.CrearCategoria(objCategoria.Descripcion, objCategoria.Foto, objCategoria.Estado))
                {
                        return RedirectToAction("Index");

                 }
                 else{
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
                var dato = categoria.ConsultarCategoria(id);
                
                Categoria objCategoria = new Categoria();

                objCategoria.CodCategoria = dato.CodigoCategoria;
                objCategoria.Descripcion = dato.Descripción;
                objCategoria.Foto = dato.Foto.ToArray();
                objCategoria.Estado = dato.Estado;
                

                return View(objCategoria);
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        [HttpPost]
        public ActionResult Eliminar(Categoria objCategoria)
        {
            try
            {
                if (categoria.EliminarCategoria(objCategoria.CodCategoria))
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