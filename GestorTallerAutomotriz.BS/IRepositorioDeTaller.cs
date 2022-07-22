using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestorTallerAutomotriz.Model;

namespace GestorTallerAutomotriz.BS
{
public interface IRepositorioDeTaller
    {
        List<Ordenes> ObtengaLaLista();
        void Agregue(Ordenes ordenes);

        public List<Ordenes> ObTengaLasOrdenesRecibidas(Estado estado);
        public List<Ordenes> ObTengaLasOrdenesEnProceso(Estado estado);

        public Ordenes ObtenerPorId(int Id);

        public void Editar(Ordenes ordenes);

        public void CancelarLaOrden(Ordenes ordenes);

        public void IniciarUnaOrden(Ordenes ordenes);

        public void CancelarUnaOrden(Ordenes ordenes);

        public void CompletarUnaOrden(Ordenes ordenes);

        public List<Ordenes> ObTengaLasOrdenesCompletadas(Estado estado);

        public List<Ordenes> ObTengaLasOrdenesCanceladas(Estado estado);

    }
}
