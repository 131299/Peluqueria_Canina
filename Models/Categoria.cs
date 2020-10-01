using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;

namespace Peluqueria_canina_chichi.Models
{
    public class Categoria
    {
        public int CodCategoria { get; set; }
        public string Descripcion { get; set; }
        public byte[] Foto { get; set; }
        public bool Estado { get; set; }
    }
}