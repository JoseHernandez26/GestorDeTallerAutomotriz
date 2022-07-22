using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GestorTallerAutomotriz.Model
{
    public class Ordenes
    {

        public int Id { get; set; }
        public string NombreDelCliente { get; set; }

        public string Placa { get; set; }


        public Tipo Tipo { get; set; }

        public string Marca { get; set; }

        public Estado Estado { get; set; }

        public string DescripcionDelProblema { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaDeIngreso { get; set; }

        public string? MotivoDeLaCancelacion { get; set; }

        public string? NombreDelMecanico { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? FechaDeInicioDeAtencion { get; set; }

        public string? DescripcionDeLaReparacion { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? FechaFinalDeAtencion { get; set; }

        [NotMapped]
        public int CantidadDeDiasEnTaller { get; set; }
        [NotMapped]
        public int CantidadDeDiasEnProceso { get; set; }




    }
}
