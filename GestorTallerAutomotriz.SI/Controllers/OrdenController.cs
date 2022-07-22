using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GestorTallerAutomotriz.Model;

namespace GestorTallerAutomotriz.SI.Controllers
{
    public class OrdenController : Controller
    {
        private readonly BS.IRepositorioDeTaller ElRepositorio;

        public OrdenController(BS.IRepositorioDeTaller repositorio)
        {
            ElRepositorio = repositorio;
        }
        [HttpGet("ObtengaLaLista")]
        public IEnumerable<Ordenes> ObtengaLaLista()
        {
            List<Ordenes> elResultado;
            elResultado = ElRepositorio.ObtengaLaLista();
            return elResultado;
        }
        [HttpPost("AgregarOrden")]
        public IActionResult Post([FromBody] Ordenes ordenes)
        {

            if (ModelState.IsValid)
            {
                ElRepositorio.Agregue(ordenes);
                return Ok(ordenes);
            }
            else
            {
                return BadRequest(ModelState);
            }

        }
        // GET: OrdenController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrdenController/Create
   

        // GET: OrdenController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }
        [HttpGet("ObTengaLasOrdenesRecibidas")]
        public IEnumerable<Ordenes> ObTengaLasOrdenesRecibidas(Estado estado)
        {
            List<Ordenes> elResultado;
            elResultado = ElRepositorio.ObTengaLasOrdenesRecibidas(estado);
            return elResultado;
        }
        // POST: OrdenController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        [HttpGet("ObTengaLasOrdenesEnProceso")]
        public IEnumerable<Ordenes> ObTengaLasOrdenesEnProceso(Estado estado)
        {
            List<Ordenes> elResultado;
            elResultado = ElRepositorio.ObTengaLasOrdenesEnProceso(estado);
            return elResultado;
        }
        // POST: OrdenController/Edit/5



        [HttpGet("ObTengaLasOrdenesCompletadas")]
        public IEnumerable<Ordenes> ObTengaLasOrdenesCompletadas(Estado estado)
        {
            List<Ordenes> elResultado;
            elResultado = ElRepositorio.ObTengaLasOrdenesCompletadas(estado);
            return elResultado;
        }
        [HttpGet("ObtenerPorId")]
        public Ordenes ObtenerPorId(int id)
        {
            Ordenes elResultado;
            elResultado = ElRepositorio.ObtenerPorId(id);
            return elResultado;
        }

        [HttpPut("EditarOrdenesRecibidas")]
        public IActionResult Put([FromBody] Ordenes ordenes)
        {

            if (ModelState.IsValid)
            {
                ElRepositorio.Editar(ordenes);
                return Ok(ordenes);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut("CancelarOrden")]
        public IActionResult CancelarOrden([FromBody] Ordenes ordenes)
        {

            if (ModelState.IsValid)
            {
                ElRepositorio.CancelarLaOrden(ordenes);
                return Ok(ordenes);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }


        [HttpPut("CancelarUnaOrden")]
        public IActionResult CancelarUnaOrden([FromBody] Ordenes ordenes)
        {

            if (ModelState.IsValid)
            {
                ElRepositorio.CancelarUnaOrden(ordenes);
                return Ok(ordenes);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }


        [HttpPut("CompletarUnaOrden")]
        public IActionResult CompletarUnaOrden([FromBody] Ordenes ordenes)
        {

            if (ModelState.IsValid)
            {
                ElRepositorio.CompletarUnaOrden(ordenes);
                return Ok(ordenes);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut("IniciarOrden")]
        public IActionResult IniciarOrden([FromBody] Ordenes ordenes)
        {

            if (ModelState.IsValid)
            {
                ElRepositorio.IniciarUnaOrden(ordenes);
                return Ok(ordenes);
            }
            else
            {
                return BadRequest(ModelState);

            }
        }



        // GET: OrdenController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrdenController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet("ObTengaLasOrdenesCanceladas")]
        public IEnumerable<Ordenes> ObTengaLasOrdenesCanceladas(Estado estado)
        {
            List<Ordenes> elResultado;
            elResultado = ElRepositorio.ObTengaLasOrdenesCompletadas(estado);
            return elResultado;
        }
    }
}
