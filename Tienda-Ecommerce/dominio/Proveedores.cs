using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Proveedores
    {
        public int IdProveedor {  get; set; }
        public string Cuit {  get; set; }
        public string Nombre { get; set; }
        public string NombreContacto { get; set; }
        public string CargoContacto { get; set; }
        public string Direccion { get; set; }
        public string Ciudad {  get; set; }
        public string CodPostal { get; set; }
        public string Telefono { get; set; }
        public bool Estado { get; set; }

    }
}
