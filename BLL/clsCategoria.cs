using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
   public  class clsCategoria
    {
		public List<ConsultarCategoriasResult> ConsultaCategorias()
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				List<ConsultarCategoriasResult> datos = db.ConsultarCategorias().ToList();
				return datos;
			}
			catch (Exception ex)
			{

				throw;
			}
		}
		public ConsultarCategoriaResult ConsultarCategoria(int CodCategoria)
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				ConsultarCategoriaResult dato = db.ConsultarCategoria(CodCategoria).FirstOrDefault();
				return dato;
			}
			catch (Exception ex)
			{

				throw;
			}
		}
		public bool ActualizarCategoria(int codCategoria,String Descripcion, Byte[]Foto, bool Estado )
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				db.ActualizarCategoria(codCategoria, Descripcion, Foto,Estado);
				return true;
			}
			catch (Exception ex)
			{

				return false;
			}
		}
		public bool CrearCategoria(String Descripcion, Byte[] Foto, bool Estado)
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				db.CrearCategoria(Descripcion, Foto, Estado);
				return true;
			}
			catch (Exception ex)
			{

				return false;
			}
		}
		public bool EliminarCategoria(int CodCategoria)
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				db.EliminarCategoria(CodCategoria);
				return true;
			}
			catch (Exception ex)
			{

				return false;
			}
		}
	}
}
