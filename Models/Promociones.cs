using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Peluqueria_canina_chichi.Models
{
    public class Promociones
    {
        public int CodPromocion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public char Dia { get; set; }
        public decimal Precio { get; set; }
        public bool Estado { get; set; }
        public int  CodProducto { get; set; }
    }
}