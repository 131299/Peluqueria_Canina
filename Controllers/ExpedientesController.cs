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
    public class ExpedientesController : Controller
    {
        clsExpedientes expediente = new clsExpedientes();

        // GET: Expedientes
        public ActionResult Index()
        {
            try
            {
                var datos = expediente.ConsultarExpedientes();

                List<Expedientes> ListaExpedientes = new List<Expedientes>();
                //HttpPostedFileBase filebase = Request.Files[0];
                //WebImage image = new WebImage(filebase.InputStream);

                foreach (var item in datos)
                {
                    //Byte[] b= new Byte[10];
                    Expedientes objExpediente = new Expedientes();
                    objExpediente.IdMacota = item.IdMascota;
                    objExpediente.Nombre = item.Nombre;
                    objExpediente.Especie = item.Especie;
                    objExpediente.Sexo = item.Sexo;
                    objExpediente.Raza = item.Raza;
                    objExpediente.Color = item.Color;
                    objExpediente.Nacimiento = item.FechaNacimiento.GetValueOrDefault();
                    objExpediente.Alergias = item.Alergias;
                    objExpediente.Enfermedades = item.Enfermedades;
                    objExpediente.Nota = item.Notas;
                    objExpediente.Foto = item.Foto.ToArray();
                    
                    ListaExpedientes.Add(objExpediente);
                }

                return View(ListaExpedientes);
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
                var dato = expediente.ConsultarExpediente(id);

                Expedientes objExpediente = new Expedientes();
                objExpediente.IdMacota = dato.IdMascota;
                objExpediente.Nombre = dato.Nombre;
                objExpediente.Especie = dato.Especie;
                objExpediente.Sexo = dato.Sexo;
                objExpediente.Raza =dato.Raza;
                objExpediente.Color = dato.Color;
                objExpediente.Nacimiento = dato.FechaNacimiento.GetValueOrDefault();
                objExpediente.Alergias = dato.Alergias;
                objExpediente.Enfermedades = dato.Enfermedades;
                objExpediente.Nota = dato.Notas;
                objExpediente.Foto = dato.Foto.ToArray();

                return View(objExpediente);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        [HttpPost]
        public ActionResult Editar(Expedientes objExpediente, HttpPostedFileBase UploadImage)
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
                    objExpediente.Foto = ImagenData;
                }
                if (expediente.ActualizarExpediente(objExpediente.IdMacota, objExpediente.Nombre, objExpediente.Especie, objExpediente.Sexo, objExpediente.Raza,
                    objExpediente.Color, objExpediente.Nacimiento, objExpediente.Alergias, objExpediente.Enfermedades, objExpediente.Nota, objExpediente.Foto))
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
        public ActionResult Crear(Expedientes objExpediente, HttpPostedFileBase UploadImage)
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
                    objExpediente.Foto = ImagenData;
                }
                if (expediente.CrearExpediente(objExpediente.Nombre, objExpediente.Especie, objExpediente.Sexo, objExpediente.Raza,
                    objExpediente.Color, objExpediente.Nacimiento, objExpediente.Alergias, objExpediente.Enfermedades, objExpediente.Nota, objExpediente.Foto))
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
                var dato = expediente.ConsultarExpediente(id);

                Expedientes objExpediente = new Expedientes();

                objExpediente.IdMacota = dato.IdMascota;
                objExpediente.Nombre = dato.Nombre;
                objExpediente.Especie = dato.Especie;
                objExpediente.Sexo = dato.Sexo;
                objExpediente.Raza = dato.Raza;
                objExpediente.Color = dato.Color;
                objExpediente.Nacimiento = dato.FechaNacimiento.GetValueOrDefault();
                objExpediente.Alergias = dato.Alergias;
                objExpediente.Enfermedades = dato.Enfermedades;
                objExpediente.Nota = dato.Notas;
                objExpediente.Foto = dato.Foto.ToArray();


                return View(objExpediente);
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        [HttpPost]
        public ActionResult Eliminar(Expedientes objExpediente)
        {
            try
            {
                if (expediente.EliminarExpediente(objExpediente.IdMacota))
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