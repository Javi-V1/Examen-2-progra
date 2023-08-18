using Capa_Logica.Orquestador;
using Capa_Modelo.Articulo;
using Microsoft.AspNetCore.Mvc;

namespace Capa_Controller.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ExamenController : Controller
    {
        private OrquestadorExamen orquestador = new OrquestadorExamen();

        [HttpGet]
        [Route("ObtenerArticulos")]
        public IActionResult ObtenerArticulos()
        {
            List<Articulo> articulos = orquestador.ObtenerListaArticulos();
            return Ok(articulos);
        }

        [HttpPost]
        [Route("AñadirListaArticulo")]
        public IActionResult AgregarListaArticulo(List<Articulo> _articulos)
        {
            bool result = orquestador.AgregarListaArticulos(_articulos);
            return result ? Ok() : BadRequest();
        }

        [HttpPut]
        [Route("ActualizarArticulos2")]
        public IActionResult ActualizarArticulos2(int cantidad)
        {
            bool resultado = orquestador.ActualizarArticulos2(cantidad);
            return resultado ? Ok() : BadRequest();
        }

        [HttpDelete]
        [Route("EliminarArticulos")]
        public IActionResult EliminarArticulos()
        {
            bool resultado = orquestador.EliminarArticulos();
            return resultado ? Ok() : BadRequest();
        }
    }
}
