using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using GestorTallerAutomotriz.Model;

namespace GestorTallerAutomotriz.UI.Controllers
{
    public class OrdenController : Controller
    {
        // GET: OrdenController
       
        // GET: OrdenController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrdenController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstudianteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Ordenes ordenes)
        {
            try
            {

                Ordenes lasOrdenes = new Model.Ordenes();

                lasOrdenes.NombreDelCliente = ordenes.NombreDelCliente;
                lasOrdenes.Placa = ordenes.Placa;
                lasOrdenes.Tipo = ordenes.Tipo;

               
                lasOrdenes.Marca = ordenes.Marca;
                lasOrdenes.DescripcionDelProblema = ordenes.DescripcionDelProblema;
                lasOrdenes.FechaDeIngreso = ordenes.FechaDeIngreso;
                ordenes.Estado = Estado.Recibida;
                lasOrdenes.Estado = ordenes.Estado;

                

                var httpClient = new HttpClient();

                string json = JsonConvert.SerializeObject(ordenes);

                var buffer = System.Text.Encoding.UTF8.GetBytes(json);

                var byteContent = new ByteArrayContent(buffer);

                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                await httpClient.PostAsync("https://localhost:7288/AgregarOrden", byteContent);
         
                return RedirectToAction(nameof(ObtengaLaListaDeOrdenesRecibidas));
            }
            catch
            {
                return View();
            }
        }

        public async Task<IActionResult> ObtengaLaListaDeOrdenesRecibidas(string nombre)
        {

            List<Ordenes> laLista;


            try
            {

                var httpClient = new HttpClient();

                if (nombre is null)
                {
                    var response = await httpClient.GetAsync("https://localhost:7288/ObTengaLasOrdenesRecibidas");
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    laLista = JsonConvert.DeserializeObject<List<Ordenes>>(apiResponse);

                }
                else
                {
                    var query = new Dictionary<string, string>()
                    {

                        ["nombre"] = nombre
                    };

                    var uri = QueryHelpers.AddQueryString("https://localhost:7288/ObTengaLasOrdenesRecibidas", query);
                    var response = await httpClient.GetAsync(uri);
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    laLista = JsonConvert.DeserializeObject<List<Ordenes>>(apiResponse);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View(laLista);
        }




        public async Task<IActionResult> ObtengaLaListaDeOrdenesEnProceso(string nombre)
        {

            List<Ordenes> laLista;


            try
            {

                var httpClient = new HttpClient();

                if (nombre is null)
                {
                    var response = await httpClient.GetAsync("https://localhost:7288/ObTengaLasOrdenesEnProceso");
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    laLista = JsonConvert.DeserializeObject<List<Ordenes>>(apiResponse);
                    foreach (Ordenes item in laLista)
                    {
                        if (item.FechaDeInicioDeAtencion!=null) {
                            TempData["dias"] = item.FechaDeInicioDeAtencion.Value.Day;
                            int losDias = (int)TempData["dias"];
                            item.CantidadDeDiasEnProceso = losDias - DateTime.Now.Day;
                            int a = losDias;
                        }


                    }

                }
                else
                {
                    var query = new Dictionary<string, string>()
                    {

                        ["nombre"] = nombre
                    };

                    var uri = QueryHelpers.AddQueryString("https://localhost:7288/ObTengaLasOrdenesEnProcesos", query);
                    var response = await httpClient.GetAsync(uri);
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    laLista = JsonConvert.DeserializeObject<List<Ordenes>>(apiResponse);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View(laLista);
        }



        public async Task<IActionResult> ObtengaLaListaDeOrdenesCompletadas(string nombre)
        {

            List<Ordenes> laLista;


            try
            {

                var httpClient = new HttpClient();

                if (nombre is null)
                {
                    var response = await httpClient.GetAsync("https://localhost:7288/ObTengaLasOrdenesCompletadas");
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    laLista = JsonConvert.DeserializeObject<List<Ordenes>>(apiResponse);
                    foreach (Ordenes item in laLista)
                    {
                        if (item.FechaDeInicioDeAtencion != null)
                        {
                            TempData["dias"] = item.FechaDeInicioDeAtencion.Value.Day;
                            int losDias = (int)TempData["dias"];
                            item.CantidadDeDiasEnProceso = losDias - DateTime.Now.Day;
                            int a = losDias;
                        }


                    }

                }
                else
                {
                    var query = new Dictionary<string, string>()
                    {

                        ["nombre"] = nombre
                    };

                    var uri = QueryHelpers.AddQueryString("https://localhost:7288/ObTengaLasOrdenesCompletadas", query);
                    var response = await httpClient.GetAsync(uri);
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    laLista = JsonConvert.DeserializeObject<List<Ordenes>>(apiResponse);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View(laLista);
        }


        public async Task<IActionResult> ObtengaLaListaDeOrdenesCanceladas(string nombre)
        {

            List<Ordenes> laLista;


            try
            {

                var httpClient = new HttpClient();

                if (nombre is null)
                {
                    var response = await httpClient.GetAsync("https://localhost:7288/ObTengaLasOrdenesCanceladas");
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    laLista = JsonConvert.DeserializeObject<List<Ordenes>>(apiResponse);
    

                }
                else
                {
                    var query = new Dictionary<string, string>()
                    {

                        ["nombre"] = nombre
                    };

                    var uri = QueryHelpers.AddQueryString("https://localhost:7288/ObTengaLasOrdenesCanceladas", query);
                    var response = await httpClient.GetAsync(uri);
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    laLista = JsonConvert.DeserializeObject<List<Ordenes>>(apiResponse);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View(laLista);
        }

        // GET: OrdenController/Edit/5
        public async Task<IActionResult> Edit(int Id)
        {

           Ordenes lasOrden;

            try

            {
                var httpClient = new HttpClient();

                var query = new Dictionary<string, string>()
                {

                    ["id"] = Id.ToString()
                };

                var uri = QueryHelpers.AddQueryString("https://localhost:7288/ObtenerPorId", query);
                var response = await httpClient.GetAsync(uri);
                string apiResponse = await response.Content.ReadAsStringAsync();

                lasOrden = JsonConvert.DeserializeObject<Ordenes>(apiResponse);

            }
            catch (Exception ex)
            {
                throw ex;

            }

            return View(lasOrden);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Ordenes ordenes)
        {
            try
            {

                var httpClient = new HttpClient();

                string json = JsonConvert.SerializeObject(ordenes);

                var buffer = System.Text.Encoding.UTF8.GetBytes(json);

                var byteContent = new ByteArrayContent(buffer);

                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                await httpClient.PutAsync("https://localhost:7288/EditarOrdenesRecibidas", byteContent);


                return RedirectToAction(nameof(ObtengaLaListaDeOrdenesRecibidas));
            }
            catch
            {
                return View();
            }
        }




        public async Task<IActionResult> DetalleOrden(int Id)
        {

            Ordenes laOrden;

            try

            {
                var httpClient = new HttpClient();
                var query = new Dictionary<string, string>()
                {

                    ["id"] = Id.ToString()
                };

                var uri = QueryHelpers.AddQueryString("https://localhost:7288/ObtenerPorId", query);
                var response = await httpClient.GetAsync(uri);
                string apiResponse = await response.Content.ReadAsStringAsync();
                laOrden = JsonConvert.DeserializeObject<Ordenes>(apiResponse);
            }
            catch (Exception ex)
            {
                throw ex;

            }

            return View(laOrden);
        }

        public async Task<IActionResult> DetalleOrdenCancelada(int Id)
        {

            Ordenes laOrden;

            try

            {
                var httpClient = new HttpClient();
                var query = new Dictionary<string, string>()
                {

                    ["id"] = Id.ToString()
                };

                var uri = QueryHelpers.AddQueryString("https://localhost:7288/ObtenerPorId", query);
                var response = await httpClient.GetAsync(uri);
                string apiResponse = await response.Content.ReadAsStringAsync();
                laOrden = JsonConvert.DeserializeObject<Ordenes>(apiResponse);
            }
            catch (Exception ex)
            {
                throw ex;

            }

            return View(laOrden);
        }

        public async Task<IActionResult> DetalleOrdenCompletada(int Id)
        {

            Ordenes laOrden;

            try

            {
                var httpClient = new HttpClient();
                var query = new Dictionary<string, string>()
                {

                    ["id"] = Id.ToString()
                };

                var uri = QueryHelpers.AddQueryString("https://localhost:7288/ObtenerPorId", query);
                var response = await httpClient.GetAsync(uri);
                string apiResponse = await response.Content.ReadAsStringAsync();
                laOrden = JsonConvert.DeserializeObject<Ordenes>(apiResponse);
            }
            catch (Exception ex)
            {
                throw ex;

            }

            return View(laOrden);
        }



        public async Task<IActionResult> CancelarOrden(int Id)
        {

            Ordenes lasOrden;

            try

            {
                var httpClient = new HttpClient();

                var query = new Dictionary<string, string>()
                {

                    ["id"] = Id.ToString()
                };

                var uri = QueryHelpers.AddQueryString("https://localhost:7288/ObtenerPorId", query);
                var response = await httpClient.GetAsync(uri);
                string apiResponse = await response.Content.ReadAsStringAsync();

                lasOrden = JsonConvert.DeserializeObject<Ordenes>(apiResponse);

            }
            catch (Exception ex)
            {
                throw ex;

            }

            return View(lasOrden);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CancelarOrden(Ordenes ordenes)
        {
            try
            {

                var httpClient = new HttpClient();

                string json = JsonConvert.SerializeObject(ordenes);

                var buffer = System.Text.Encoding.UTF8.GetBytes(json);

                var byteContent = new ByteArrayContent(buffer);

                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                await httpClient.PutAsync("https://localhost:7288/CancelarOrden", byteContent);


                return RedirectToAction(nameof(ObtengaLaListaDeOrdenesRecibidas));
            }
            catch
            {
                return View();
            }
        }




        public async Task<IActionResult> CancelarUnaOrden(int Id)
        {

            Ordenes lasOrden;

            try

            {
                var httpClient = new HttpClient();

                var query = new Dictionary<string, string>()
                {

                    ["id"] = Id.ToString()
                };

                var uri = QueryHelpers.AddQueryString("https://localhost:7288/ObtenerPorId", query);
                var response = await httpClient.GetAsync(uri);
                string apiResponse = await response.Content.ReadAsStringAsync();

                lasOrden = JsonConvert.DeserializeObject<Ordenes>(apiResponse);

            }
            catch (Exception ex)
            {
                throw ex;

            }

            return View(lasOrden);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CancelarUnaOrden(Ordenes ordenes)
        {
            try
            {

                var httpClient = new HttpClient();

                string json = JsonConvert.SerializeObject(ordenes);

                var buffer = System.Text.Encoding.UTF8.GetBytes(json);

                var byteContent = new ByteArrayContent(buffer);

                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                await httpClient.PutAsync("https://localhost:7288/CancelarUnaOrden", byteContent);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public async Task<IActionResult> CompletarUnaOrden(int Id)
        {

            Ordenes lasOrden;

            try

            {
                var httpClient = new HttpClient();

                var query = new Dictionary<string, string>()
                {

                    ["id"] = Id.ToString()
                };

                var uri = QueryHelpers.AddQueryString("https://localhost:7288/ObtenerPorId", query);
                var response = await httpClient.GetAsync(uri);
                string apiResponse = await response.Content.ReadAsStringAsync();

                lasOrden = JsonConvert.DeserializeObject<Ordenes>(apiResponse);

            }
            catch (Exception ex)
            {
                throw ex;

            }

            return View(lasOrden);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CompletarUnaOrden(Ordenes ordenes)
        {
            try
            {

                var httpClient = new HttpClient();

                string json = JsonConvert.SerializeObject(ordenes);

                var buffer = System.Text.Encoding.UTF8.GetBytes(json);

                var byteContent = new ByteArrayContent(buffer);

                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                await httpClient.PutAsync("https://localhost:7288/CompletarUnaOrden", byteContent);


                return RedirectToAction(nameof(ObtengaLaListaDeOrdenesRecibidas));
            }
            catch
            {
                return View();
            }
        }


        public async Task<IActionResult> IniciarOrden(int Id)
        {

            Ordenes lasOrden;

            try

            {
                var httpClient = new HttpClient();

                var query = new Dictionary<string, string>()
                {

                    ["id"] = Id.ToString()
                };

                var uri = QueryHelpers.AddQueryString("https://localhost:7288/ObtenerPorId", query);
                var response = await httpClient.GetAsync(uri);
                string apiResponse = await response.Content.ReadAsStringAsync();

                lasOrden = JsonConvert.DeserializeObject<Ordenes>(apiResponse);

            }
            catch (Exception ex)
            {
                throw ex;

            }

            return View(lasOrden);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IniciarOrden(Ordenes ordenes)
        {
            try
            {

                var httpClient = new HttpClient();

                string json = JsonConvert.SerializeObject(ordenes);

                var buffer = System.Text.Encoding.UTF8.GetBytes(json);

                var byteContent = new ByteArrayContent(buffer);

                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                await httpClient.PutAsync("https://localhost:7288/IniciarOrden", byteContent);


                return RedirectToAction(nameof(ObtengaLaListaDeOrdenesRecibidas));
            }
            catch
            {
                return View();
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
                return RedirectToAction(nameof(ObtengaLaListaDeOrdenesRecibidas));
            }
            catch
            {
                return View();
            }
        }
    }
}
