using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Peluqueria_canina_chichi.Models
{
    public class Productos
    {
        public int CodProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion  { get; set; }
        public byte[] Foto { get; set; }
        public string Marca { get; set; }
        public decimal Precio { get; set; }
        public decimal Iva { get; set; }
        public int  Stock { get; set; }
        public bool Estado { get; set; }
        public int CodProovedor { get; set; }
        public int CodCategoria { get; set; }
    }
}