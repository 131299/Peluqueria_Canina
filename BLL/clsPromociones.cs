using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
	public class clsPromociones
	{
		public List<ConsultarPromocionesResult> ConsulatarPromociones()
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				List<ConsultarPromocionesResult> datos = db.ConsultarPromociones().ToList();
				return datos;
			}
			catch (Exception ex)
			{

				throw;
			}
		}
		public ConsultarPromocionResult ConsultarPromocion(int CodPromocion)
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				ConsultarPromocionResult dato = db.ConsultarPromocion(CodPromocion).FirstOrDefault();
				return dato;
			}
			catch (Exception ex)
			{

				throw;
			}
		}
		public bool ActualizarPromocion(int CodPromo,DateTime FechaInicio, DateTime FechaFin, char Dia, decimal Precio, bool estado,
			int codProducto)
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				db.ActualizaPromocion(CodPromo,FechaInicio,FechaFin,Dia,Precio,estado,codProducto);
				return true;
			}
			catch (Exception ex)
			{

				return false;
			}
		}
		public bool CrearPromocion(DateTime FechaInicio, DateTime FechaFin, char Dia, decimal Precio, bool estado,
			int codProducto)
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				db.CrearPromocion(FechaInicio, FechaFin, Dia, Precio,estado,codProducto);
				return true;
			}
			catch (Exception ex)
			{

				return false;
			}
		}
		public bool EliminaPromocion(int codPromocion)
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				db.EliminarPromocion(codPromocion);
				return true;
			}
			catch (Exception ex)
			{

				return false;
			}
		}
    }
}
