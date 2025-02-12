using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class DetalleVenta
    {
        public string NroFactura { get; set; }
        public int IdArticulo { get; set; }
        public string NombreArticulo { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }

    }
}
