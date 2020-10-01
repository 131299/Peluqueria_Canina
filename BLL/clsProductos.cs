using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
   public class clsProductos
    {
		public List<ConsultarProductosResult> ConsultarProductos()
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				List<ConsultarProductosResult> datos = db.ConsultarProductos().ToList();
				return datos;
			}
			catch (Exception ex)
			{

				throw;
			}
		}
		public ConsultarProductoResult ConsultarProducto(int CodProducto)
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				ConsultarProductoResult dato = db.ConsultarProducto(CodProducto).FirstOrDefault();
				return dato;
			}
			catch (Exception ex)
			{

				throw;
			}
		}
		public bool ActualizarProducto(int CodProducto,string nombre, string Descripcion, byte[] Foto, string Marca, decimal Precio, decimal Iva,
			int Stock, bool Estado, int CodProovedor, int CodCategoria) 
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				db.ActualizarProducto(CodProducto,nombre,Descripcion, Foto, Marca, Precio, Iva, Stock, Estado, CodProovedor, CodCategoria);
				return true;
			}
			catch (Exception ex)
			{

				return false;
			}
		}
		public bool AgregarProducto(string nombre, string Descripcion, byte[] Foto, string Marca, decimal Precio, decimal Iva,
			int Stock, bool Estado, int CodProovedor, int CodCategoria)
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				db.AgregarProductos(nombre, Descripcion, Foto, Marca, Precio, Iva, Stock, Estado, CodProovedor, CodCategoria);
				return true;
			}
			catch (Exception ex)
			{

				return false;
			}
		}
		public bool EliminarProductos(int CodProducto)
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				db.EliminarProducto(CodProducto);
				return true;
			}
			catch (Exception ex)
			{

				return false;
			}
		}
	}
}
