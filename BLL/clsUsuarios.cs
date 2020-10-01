using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
    public class clsUsuarios
    {
        public ValidarUsuarioResult validarUsuario(string Correo, string Clave)
        {
            try
            {
                DatosDataContext db = new DatosDataContext();
                ValidarUsuarioResult dato = db.ValidarUsuario(Correo, Clave).FirstOrDefault();
                return dato;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
