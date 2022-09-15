using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdgarAguilar.Models
{
    public class ProductoDTO
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Categoria { get; set; }
        public double Precio { get; set; }
        public int Cantidad { get; set; }
       
    }
}
