using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Peluqueria_canina_chichi.Models
{
    public class Expedientes
    {
        public int IdMacota { get; set; }
        public string Nombre { get; set; }
        public string Especie { get; set; }
        public string Sexo { get; set; }
        public string Raza { get; set; }
        public string Color { get; set; }
        public DateTime Nacimiento { get; set; }
        public string Alergias  { get; set; }
        public string Enfermedades { get; set; }
        public string Nota { get; set; }
        public Byte[] Foto { get; set; }
    }

    
}