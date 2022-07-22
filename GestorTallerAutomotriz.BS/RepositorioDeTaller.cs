using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestorTallerAutomotriz.Model;

namespace GestorTallerAutomotriz.BS
{
    public class RepositorioDeTaller:IRepositorioDeTaller
    {
        private GestorTallerAutomotriz.DA.DbContexto ElContextoBD;


        List<int> laListaDeDiasDeLaFecha=new List<int>();
        int DiasDeInicioDeAtencion;

        public RepositorioDeTaller(GestorTallerAutomotriz.DA.DbContexto contexto)
        {
            ElContextoBD = contexto;
        }

        public void Editar(Ordenes ordenes)
        {
            Ordenes laOrdenAmodificar;

            laOrdenAmodificar = ObtenerPorId(ordenes.Id);

            laOrdenAmodificar.NombreDelCliente = ordenes.NombreDelCliente;
            laOrdenAmodificar.Placa = ordenes.Placa;
            laOrdenAmodificar.Tipo = ordenes.Tipo;


            laOrdenAmodificar.Marca = ordenes.Marca;
            laOrdenAmodificar.DescripcionDelProblema = ordenes.DescripcionDelProblema;
            laOrdenAmodificar.FechaDeIngreso = ordenes.FechaDeIngreso;
            ordenes.Estado = Estado.Recibida;
            laOrdenAmodificar.Estado = ordenes.Estado;

            ElContextoBD.Ordenes.Update(laOrdenAmodificar);
            ElContextoBD.SaveChanges();
        }

        public void CancelarLaOrden(Ordenes ordenes)
        {
            Ordenes laOrdenAmodificar;

            laOrdenAmodificar = ObtenerPorId(ordenes.Id);

            laOrdenAmodificar.NombreDelCliente = ordenes.NombreDelCliente;
            laOrdenAmodificar.Placa = ordenes.Placa;
            laOrdenAmodificar.Tipo = ordenes.Tipo;


            laOrdenAmodificar.Marca = ordenes.Marca;
            laOrdenAmodificar.DescripcionDelProblema = ordenes.DescripcionDelProblema;
            laOrdenAmodificar.FechaDeIngreso = ordenes.FechaDeIngreso;
            laOrdenAmodificar.Estado = Estado.Proceso;
            laOrdenAmodificar.FechaDeInicioDeAtencion = DateTime.Now;

            laOrdenAmodificar.MotivoDeLaCancelacion = ordenes.MotivoDeLaCancelacion;
            laOrdenAmodificar.NombreDelMecanico = ordenes.NombreDelMecanico;
            ElContextoBD.Ordenes.Update(laOrdenAmodificar);
            ElContextoBD.SaveChanges();
        }

        public void IniciarUnaOrden(Ordenes ordenes)
        {
            Ordenes laOrdenAmodificar;

            laOrdenAmodificar = ObtenerPorId(ordenes.Id);

            laOrdenAmodificar.NombreDelCliente = ordenes.NombreDelCliente;
            laOrdenAmodificar.Placa = ordenes.Placa;
            laOrdenAmodificar.Tipo = ordenes.Tipo;


            laOrdenAmodificar.Marca = ordenes.Marca;
            laOrdenAmodificar.DescripcionDelProblema = ordenes.DescripcionDelProblema;
            laOrdenAmodificar.FechaDeIngreso = ordenes.FechaDeIngreso;
            laOrdenAmodificar.Estado = Estado.Proceso;
            laOrdenAmodificar.FechaDeInicioDeAtencion = DateTime.Now;
            
            laOrdenAmodificar.MotivoDeLaCancelacion = ordenes.MotivoDeLaCancelacion;
            laOrdenAmodificar.NombreDelMecanico = ordenes.NombreDelMecanico;
            ElContextoBD.Ordenes.Update(laOrdenAmodificar);
            ElContextoBD.SaveChanges();
        }


        public void CancelarUnaOrden(Ordenes ordenes)
        {
            Ordenes laOrdenAmodificar;

            laOrdenAmodificar = ObtenerPorId(ordenes.Id);

            laOrdenAmodificar.NombreDelCliente = ordenes.NombreDelCliente;
            laOrdenAmodificar.Placa = ordenes.Placa;
            laOrdenAmodificar.Tipo = ordenes.Tipo;


            laOrdenAmodificar.Marca = ordenes.Marca;
            laOrdenAmodificar.DescripcionDelProblema = ordenes.DescripcionDelProblema;
            laOrdenAmodificar.FechaDeIngreso = ordenes.FechaDeIngreso;
            laOrdenAmodificar.Estado = Estado.Cancelada;
            laOrdenAmodificar.FechaDeInicioDeAtencion = DateTime.Now;
            laOrdenAmodificar.MotivoDeLaCancelacion = ordenes.MotivoDeLaCancelacion;
         
            laOrdenAmodificar.NombreDelMecanico = ordenes.NombreDelMecanico;
            ElContextoBD.Ordenes.Update(laOrdenAmodificar);
            ElContextoBD.SaveChanges();
        }

        public void CompletarUnaOrden(Ordenes ordenes)
        {
            Ordenes laOrdenAmodificar;

            laOrdenAmodificar = ObtenerPorId(ordenes.Id);

            laOrdenAmodificar.NombreDelCliente = ordenes.NombreDelCliente;
            laOrdenAmodificar.Placa = ordenes.Placa;
            laOrdenAmodificar.Tipo = ordenes.Tipo;


            laOrdenAmodificar.Marca = ordenes.Marca;
            laOrdenAmodificar.DescripcionDelProblema = ordenes.DescripcionDelProblema;
            laOrdenAmodificar.FechaDeIngreso = ordenes.FechaDeIngreso;
            laOrdenAmodificar.Estado = Estado.Completada;
            laOrdenAmodificar.FechaDeInicioDeAtencion = DateTime.Now;
            laOrdenAmodificar.MotivoDeLaCancelacion = ordenes.MotivoDeLaCancelacion;
            laOrdenAmodificar.DescripcionDeLaReparacion = ordenes.DescripcionDeLaReparacion;
            laOrdenAmodificar.FechaFinalDeAtencion = DateTime.Now;
            laOrdenAmodificar.NombreDelMecanico = ordenes.NombreDelMecanico;
            ElContextoBD.Ordenes.Update(laOrdenAmodificar);
            ElContextoBD.SaveChanges();
        }




        public void Agregue(Ordenes Ordenes)
        {
           
            ElContextoBD.Ordenes.Add(Ordenes);
            ElContextoBD.SaveChanges();
        }

        public List<Ordenes> ObtengaLaLista()
        {

            var resultado = from c in ElContextoBD.Ordenes
                            select c;
            return resultado.ToList();

        }

        public List<Ordenes> ObTengaLasOrdenesRecibidas(Estado estado)
        {
            List<Ordenes> laLista;
            List<Ordenes> laListaFiltrada;

            laLista = ObtengaLaLista();

            laListaFiltrada = laLista.Where(x => x.Estado.Equals(Estado.Recibida)).ToList();
            return laListaFiltrada;
        }

        public List<Ordenes> ObTengaLasOrdenesCompletadas(Estado estado)
        {
            List<Ordenes> laLista;
            List<Ordenes> laListaFiltrada;

            laLista = ObtengaLaLista();

            laListaFiltrada = laLista.Where(x => x.Estado.Equals(Estado.Completada)).ToList();
            return laListaFiltrada;
        }
        public List<Ordenes> ObTengaLasOrdenesCanceladas(Estado estado)
        {
            List<Ordenes> laLista;
            List<Ordenes> laListaFiltrada;

            laLista = ObtengaLaLista();

            laListaFiltrada = laLista.Where(x => x.Estado.Equals(Estado.Cancelada)).ToList();
            return laListaFiltrada;
        }
        public List<Ordenes> ObTengaLasOrdenesEnProceso(Estado estado)
        {

            List<Ordenes> laLista;
            List<Ordenes> laListaFiltrada;

            laLista = ObtengaLaLista();

            laListaFiltrada = laLista.Where(x => x.Estado.Equals(Estado.Proceso)).ToList();
            foreach (Ordenes item in laLista)
            {
             


                
                item.CantidadDeDiasEnTaller = item.FechaDeIngreso.Day - DateTime.Now.Day;

            }
            return laListaFiltrada;
        }

        public Ordenes ObtenerPorId(int Id)
        {
            Ordenes resultado;

            resultado = ElContextoBD.Ordenes.Find(Id);

            return resultado;
        }
    }
}
