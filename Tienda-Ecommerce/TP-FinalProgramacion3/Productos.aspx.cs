using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_FinalProgramacion3
{
    public partial class Productos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Aquí no es necesario cargar los productos, ya que todo se maneja con JavaScript en el front-end
        }

        
        protected void btnReset_Click(object sender, EventArgs e)
        {
            // Aquí solo resetearíamos los filtros del front-end si fuera necesario
            // Pero, como se gestiona con JavaScript, este método no hace nada
        }

        // El evento de cambio de filtros también es innecesario aquí, ya que se gestiona completamente con JavaScript
        protected void FiltrosChanged(object sender, EventArgs e)
        {
            // No es necesario manejar los filtros aquí porque todo se hace en JavaScript
        }
    }
}