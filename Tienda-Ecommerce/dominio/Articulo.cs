using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Articulo
    {
        public int IdArticulo { get; set; }
        public string Descripcion { get; set; }
        public int IdCategoria {  get; set; }
        public string NombreCategoria { get; set; }
        public int IdMarca {  get; set; }
        public string NombreMarca {  get; set; }
        public int IdProveedor {  get; set; }
        public string Nombre { get; set; }
        public int Stock { get; set; }
        public string UrlImagen {  get; set; }
        public decimal Precio {  get; set; }
        public int StockMinimo { get; set; }
        public bool Estado {  get; set; }

        public Articulo() { }
    }
}
