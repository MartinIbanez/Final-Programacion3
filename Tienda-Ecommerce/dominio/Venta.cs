using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Venta
    {
        public string NroFactura { get; set; }
        public string Dni {  get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public string MetodoPago { get; set; }

    }
}
