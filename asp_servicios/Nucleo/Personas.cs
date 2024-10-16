using System.ComponentModel.DataAnnotations;

namespace asp_servicios.Nucleo
{
    public class Personas
    {
        [Key] public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Cedula { get; set; }
        public decimal Pago { get; set; }
        public DateTime Fecha { get; set; }
        public string? Departamento { get; set; }
        public bool Atendido { get; set; }
    }
}
