using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
    public class clsExpedientes
    {
		public List<ConsultarExpedientesResult> ConsultarExpedientes()
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				List<ConsultarExpedientesResult> datos = db.ConsultarExpedientes().ToList();
				return datos;
			}
			catch (Exception ex)
			{

				throw;
			}
		}
		public ConsultarExpedienteResult ConsultarExpediente(int IdMascota)
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				ConsultarExpedienteResult dato = db.ConsultarExpediente(IdMascota).FirstOrDefault();
				return dato;
			}
			catch (Exception ex)
			{

				throw;
			}
		}
		public bool ActualizarExpediente(int IdMascota, string nombre, string especie, string sexo, string raza, string color,DateTime nacimineto,
			string alergias, string enfermedades, string nota, byte[] foto)
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				db.ActualizarExpediente(IdMascota,nombre,especie,sexo,raza,color,nacimineto,alergias,enfermedades,nota, foto);
				return true;
			}
			catch (Exception ex)
			{

				return false;
			}
		}
		public bool CrearExpediente(string nombre, string especie, string sexo, string raza, string color, DateTime nacimineto,
			string alergias, string enfermedades, string nota, byte[] foto)
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				db.CrearExpediente(nombre, especie, sexo, raza, color, nacimineto, alergias, enfermedades, nota, foto);
				return true;
			}
			catch (Exception ex)
			{

				return false;
			}
		}
		public bool EliminarExpediente(int IdMascota)
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				db.EliminarExpediente(IdMascota);
				return true;
			}
			catch (Exception ex)
			{

				return false;
			}
		}
	}
}
